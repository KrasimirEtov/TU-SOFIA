#include <cstring>
#include <iostream>
#include "Person.h"

Person::Person()
{

}

Person::Person(string &name, string &egn, string &address)
{
	this->name = name;
	this->egn = egn;
	this->address = address;
}

void Person::showPerson() const
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

const string Person::getName() const {
	return this->name;
}

const string Person::getEgn() const {
	return this->egn;
}

const string Person::getAddress() const {
	return this->address;
}

void Person::setName(string &name) {
	this->name = name;
}

void Person::setEgn(string &egn) {
	this->egn = egn;
}

void Person::setAddress(string &address) {
	this->address = address;
}
