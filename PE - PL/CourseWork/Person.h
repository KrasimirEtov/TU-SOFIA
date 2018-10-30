#ifndef COURSEWORK_PERSON_H
#define COURSEWORK_PERSON_H


using namespace std;
#include <string>
#include <cstring>

class Person
{
public:
	Person();
	Person(string &name, string &egn, string &address);
	void showPerson() const;
	void clean();
	const string getName() const;
	const string getEgn() const;
	const string getAddress() const;
	void setName(string &name);
	void setEgn(string &egn);
	void setAddress(string &address);
	~Person();
protected:
	string name;
	string egn;
	string address;
};


#endif //COURSEWORK_PERSON_H
