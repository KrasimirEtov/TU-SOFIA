#include <cstring>
#include <iostream>
#include "Person.h"

Person::Person()
{

}

Person::Person(string name, string egn, string address)
{
	this->name = name;
	this->egn = egn;
	this->address = address;
}

void Person::showPerson()
{
	std::cout << endl;
	std::cout << "Name: " << name << std::endl;
	std::cout << "EGN: " << egn << std::endl;
	std::cout << "Address: " << address << std::endl;
}

Person::~Person()
{
	clean();
}

void Person::clean()
{
	name.clear();
	egn.clear();
	address.clear();
}