#include<iostream>
#include<winsock2.h>

class User
{
public:
	std::string _name;
	sockaddr_in _socketaddr;

	User();
	User(std::string name, sockaddr_in socketaddr);
	~User();
};
User::User()
{

}
User::User(std::string name, sockaddr_in socketaddr)
{
	_name = name;
	_socketaddr = socketaddr;
}

User::~User()
{
}
