#include "Addresses.h"
#include "Person.h"

#include <iostream>
#include <fstream>

int main() {
	string *addresses1 = new string[SIZE] { "Sofia", "Krivodol", "Gorno Iznanadolnishte", "Vakarel", "Vraca"};
	string *addresses2 = new string[SIZE] {"Patalenica", "Dolno Iznanagornishte", "Pleven", "Belovo", "Burgas"};
	
	Addresses persons[] =
					  {
							  Addresses("Mitio Teslata", "9412345678", "Krivodol", addresses1),
							  Addresses("Chicho Bogdan", "9387654321", "Vraca", addresses2)
					  };
	
	int personsCount = sizeof(persons) / sizeof(persons[0]);

	std::ofstream file;
	file.open("Addresses.txt");
	if (!file)
	{
		std::cout << "File cannot be opened.";
	}
	else
	{
		for (int i = 0; i < personsCount; i++)
		{
			std::cout << persons[i];
			file << persons[i];
		}
		file.close();
	}
	
	string egn;
	bool doesEgnMatch = false;
	
	std::cout << "\nEnter EGN:\n";
	std::cin >> egn;
	
	for (int i = 0; i < personsCount; i++) {
		if (egn == persons[i].egn) {
			doesEgnMatch = true;
			persons[i].showAddresses();
		}
	}
	if (!doesEgnMatch)
	{
		std::cout << "\nPerson with that EGN does not exist" << endl;
	}
	
	delete[] addresses1;
	delete[] addresses2;
	return 0;
}