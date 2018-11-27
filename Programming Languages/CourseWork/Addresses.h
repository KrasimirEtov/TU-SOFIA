#ifndef COURSEWORK_ADDRESSES_H
#define COURSEWORK_ADDRESSES_H


#include <vector>
#include "Person.h"

const int SIZE = 5;

class Addresses : public Person
{
	// TODO GET AND SET METHODS
public:
	Addresses();
	Addresses(string name, string egn, string address, string addresses[]);
	~Addresses();
	friend ostream& operator<<(ostream &os, const Addresses& person);
	void showAddresses() const;
	std::vector<std::string> getMatchingAddresses() const;
public:
	string addresses[SIZE];
	int addressesCount;
};


#endif //COURSEWORK_ADDRESSES_H
