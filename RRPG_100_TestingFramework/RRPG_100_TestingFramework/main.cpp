#include "Character_Class.cpp";
#include <fstream>
#include <vector>
#include <string>
#include <iostream>
#include <list>

using namespace std;

int main() {
	
	ifstream inFile;

	cout << "------------ Welcome to the RRPG-100 Testing Framework! ------------ " << endl;
	cout << endl << "Enter [1] to Simulate a battle" << endl;
	int first_opt;
	cin >> first_opt;
	while (first_opt != 1) {
		cout << "Enter a valid option" << endl;
		cin >> first_opt;
	}

	cout << "Select 3 character from the list bellow, and type it exactly as you see it" << endl;

	inFile.open("Character_List.txt");
	
	if (inFile.is_open()) {
		string line;
		while (getline(inFile, line)) {
			cout << line << endl;
		}
		inFile.close();
	}
	else {
		cout << "Unable to open file" << endl;
		return 0;
	}

	cout << endl;

	string fileName, fileName1, fileName2;
	cin >> fileName >> fileName1 >> fileName2;

	Character partyMember, partyMember1, partyMember2;

	partyMember.setName(fileName);
	partyMember.statsTagsMods(partyMember, fileName);
	partyMember.printStats();

	partyMember1.setName(fileName1);
	partyMember1.statsTagsMods(partyMember1, fileName1);
	partyMember1.printStats();

	partyMember2.setName(fileName2);
	partyMember2.statsTagsMods(partyMember2, fileName2);
	partyMember2.printStats();

	cout << endl << "Select a boss from the list bellow, and type it exactly as you see it" << endl;

	inFile.open("Boss_List.txt");

	if (inFile.is_open()) {
		string line;
		while (getline(inFile, line)) {
			cout << line << endl;
		}
		inFile.close();
	}
	else {
		cout << "Unable to open file" << endl;
		return 0;
	}

	cout << endl;

	string bossFile;
	cin >> bossFile;

	Character boss;

	boss.setName(bossFile);
	boss.statsTagsMods(boss, bossFile);
	boss.printStats();

	string attacksFile;
	partyMember.setAttacksAndBp(partyMember, attacksFile);
	partyMember.printStats();
}


