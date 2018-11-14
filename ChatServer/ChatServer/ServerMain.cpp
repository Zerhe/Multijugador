#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include<stdio.h>
#include<winsock2.h>
#include<iostream>
#include<list>
#include"User.h"

#pragma comment(lib,"ws2_32.lib") //Winsock Library

#define BUFLEN 512  //Tamaño máximo del buffer
#define PORT 8888   //The port on which to listen for incoming data

int main()
{
	SOCKET s;
	struct sockaddr_in server, si_other;
	int slen, recv_len;
	char buf[BUFLEN];
	WSADATA wsa;

	slen = sizeof(si_other);

	std::list<User> users;
	User userActual;
	bool found = false;

	//std::map<USHORT, std::string> users;

	//Inicializa el winsock
	printf("\nInitialising Winsock...");
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
	printf("Initialised.\n");

	//Crea un socket
	if ((s = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
	{
		printf("Could not create socket : %d", WSAGetLastError());
	}
	printf("Socket created.\n");

	//Prepara la estructura sockaddr_in
	server.sin_family = AF_INET;
	server.sin_addr.s_addr = INADDR_ANY;
	server.sin_port = htons(PORT);

	//Bind
	if (bind(s, (struct sockaddr *)&server, sizeof(server)) == SOCKET_ERROR)
	{
		printf("Bind failed with error code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
	puts("Bind done");

	//keep listening for data
	while (1)
	{
		//printf("Waiting for data...");
		fflush(stdout);

		//clear the buffer by filling null, it might have previously received data
		memset(buf, '\0', BUFLEN);

		//try to receive some data, this is a blocking call
		if ((recv_len = recvfrom(s, buf, BUFLEN, 0, (struct sockaddr *) &si_other, &slen)) == SOCKET_ERROR)
		{
			printf("recvfrom() failed with error code : %d", WSAGetLastError());
			exit(EXIT_FAILURE);
		}

		// si ese usuario manda un mensaje por primera ves lo agrega a los usuarios

		for each (User user in users)
		{
			if (user._socketaddr.sin_port == si_other.sin_port)
			{
				found = true;
				userActual = user;
				break;
			}
		}
		if (!found)
		{
			User user = User(buf, si_other);
			users.push_back(user);
			userActual = user;

			printf("Nuevo usuario %s ingresado\n", user._name.c_str());

			std::string message = "Bienvenido usuario " + user._name + "\nLista de comandos: \EntrarSala, \(NombreUsurario)";

			if (sendto(s, message.data(), message.length(), 0, (struct sockaddr*) &user._socketaddr, slen) == SOCKET_ERROR)
			{
				printf("sendto() failed with error code : %d", WSAGetLastError());
				exit(EXIT_FAILURE);
			}
		}
		//sino manda su mensaje normalmente
		else
		{
			//print details of the client/peer and the data received
			printf("Received packet from %s:%d\n", inet_ntoa(si_other.sin_addr), ntohs(si_other.sin_port));
			printf("%s: %s\n", userActual._name.c_str(), buf);

			for each (User user in users)
			{
				if (user._name != userActual._name)
				{
					std::string stringName = userActual._name + ": ";

					if (sendto(s, stringName.data(), stringName.length(), 0, (struct sockaddr*) &user._socketaddr, slen) == SOCKET_ERROR)
					{
						printf("sendto() failed with error code : %d", WSAGetLastError());
						exit(EXIT_FAILURE);
					}
					if (sendto(s, buf, recv_len, 0, (struct sockaddr*) &user._socketaddr, slen) == SOCKET_ERROR)
					{
						printf("sendto() failed with error code : %d", WSAGetLastError());
						exit(EXIT_FAILURE);
					}
				}
			}
		}
		found = false;
	}

	closesocket(s);
	WSACleanup();

	return 0;
}