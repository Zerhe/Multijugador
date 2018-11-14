#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include<stdio.h>
#include<winsock2.h>
#include<iostream>
#include<conio.h>

#pragma comment(lib,"ws2_32.lib") //Winsock Library

#define SERVER "127.0.0.1"  //ip address of udp server
#define BUFLEN 512  //Tamaño máximo del buffer
#define PORT 8888   //The port on which to listen for incoming data

int main(void)
{
	struct sockaddr_in si_other;
	int s, slen = sizeof(si_other);
	int recv_len = 0;
	char buf[BUFLEN];
	char name[BUFLEN];
	//std::string name;
	std::string message;
	WSADATA wsa;

	//Initialise winsock
	printf("\nInitialising Winsock...");
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
	printf("Initialised.\n");

	//create socket
	if ((s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP)) == SOCKET_ERROR)
	{
		printf("socket() failed with error code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}

	//setup address structure
	memset((char *)&si_other, 0, sizeof(si_other));
	si_other.sin_family = AF_INET;
	si_other.sin_port = htons(PORT);
	si_other.sin_addr.S_un.S_addr = inet_addr(SERVER);

	printf("Enter User Name : ");
	gets_s(name);

	//envio el nombre de usuario
	if (sendto(s, name, strlen(name), 0, (struct sockaddr *) &si_other, slen) == SOCKET_ERROR)
	{
		printf("sendto() failed with error code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}

	//start communication
	while (1)
	{
		printf("%s : ", name);
		//gets_s(message);

		if (_kbhit())
		{
			if (message.length() < BUFLEN - 2)
			{
				message += _getch();
			}
			else
			{
				message = "\0";

			}
		}
		else if (_kbhit() && _getch() == '\r')
		{
			//send the message
			if (sendto(s, message.data(), message.length(), 0, (struct sockaddr *) &si_other, slen) == SOCKET_ERROR)
			{
				printf("sendto() failed with error code : %d", WSAGetLastError());
				exit(EXIT_FAILURE);
			}
			message = "";
		}
		else
		{
			//clear the buffer by filling null, it might have previously received data
			memset(buf, '\0', BUFLEN);
			//try to receive some data, this is a blocking call

			recv_len = recvfrom(s, buf, BUFLEN, 0, (struct sockaddr *) &si_other, &slen);
			printf("%i\n",recv_len);

			if (recv_len == SOCKET_ERROR)
			{
				printf("recvfrom() failed with error code : %d", WSAGetLastError());
				exit(EXIT_FAILURE);
			}
			else if (recv_len > 0)
			{
				puts(buf);
			}
		}
	}

	closesocket(s);
	WSACleanup();

	return 0;
}