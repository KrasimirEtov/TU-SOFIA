#ifndef COURSEWORK_PERSON_H
#define COURSEWORK_PERSON_H


using namespace std;
#include <string>
#include <cstring>

class Person
{
public:
	Person();
	Person(string name, string egn, string address);
	void showPerson();
	void clean();
	~Person();
public:
	string name;
	string egn;
	string address;
};


#endif //COURSEWORK_PERSON_H
