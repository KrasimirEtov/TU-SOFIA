#include <cstring>
#include <iostream>
#include "Addresses.h"

Addresses::Addresses()
{
	addressesCount = 0;
}

Addresses::Addresses(string name, string egn, string address, string addresses[]) : Person(name, egn, address)
{
	addressesCount = 0;
	this->name = name;
	this->egn = egn;
	this->address = address;
	
	for (int i = 0; i < SIZE; i++)
	{
		this->addresses[i] = addresses[i];
		addressesCount += 1;
	}
}

Addresses::~Addresses()
{
	Person::clean();
}

void Addresses::showAddresses() const
{
	showPerson();
	std::cout << "\nAddresses for owned properties by " << this->name <<":\n" << endl;
	for (int i = 0; i < addressesCount; i++)
	{
		std::cout << (i + 1) << ". " << addresses[i] << endl;
	}
}

ostream &operator<<(ostream& os, const Addresses& person)
{
	os << "===========================================================================" << endl;
	os << "Name: " << person.name << "\nEGN: " << person.egn << "\nAddress: " << person.address << endl;
	
	os << "\nAddresses that matches for " << person.name << " are:" << endl;
	
	std::vector<std::string> matchingAddressesNames = person.getMatchingAddresses();
	if (matchingAddressesNames.empty())
	{
		os << "No addresses were matched." << endl;
		os << "===========================================================================" << endl;
	}
	else {
		for (int i = 0; i < matchingAddressesNames.size(); i++) {
			os << "Address[" << (i) << "]: " << (i + 1) << ". " << matchingAddressesNames[i];
		}
		os << endl;
	}
	return os;
}

std::vector<std::string> Addresses::getMatchingAddresses() const
{
	std::vector<std::string> matchingAddressesNames;
	for (int i = 0; i < addressesCount; i++)
	{
		if (this->address == addresses[i]) {
			matchingAddressesNames.push_back(addresses[i]);
		}
	}
	return matchingAddressesNames;
};