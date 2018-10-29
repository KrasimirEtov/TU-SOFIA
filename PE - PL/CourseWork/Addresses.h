#ifndef COURSEWORK_ADDRESSES_H
#define COURSEWORK_ADDRESSES_H


#include <vector>
#include "Person.h"

const int SIZE = 5;

class Addresses : public Person
{
public:
	Addresses();
	Addresses(string name, string egn, string address, string addresses[]);
	~Addresses();
	friend ostream& operator<<(ostream &os, Addresses& person);
	void showAddresses();
	std::vector<std::string> getMatchingAddresses();
public:
	string addresses[SIZE];
	int addressesCount;
};


#endif //COURSEWORK_ADDRESSES_H
