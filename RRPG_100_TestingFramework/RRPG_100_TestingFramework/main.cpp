#include "Character_Class.cpp";
#include <fstream>
#include <vector>
#include <string>
#include <iostream>
#include <list>

using namespace std;

void statsTagsMods(Character partyMember, string fileName);

void setBasePower(Turn turn, string fileName);

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
	statsTagsMods(partyMember, fileName);

	partyMember1.setName(fileName1);
	statsTagsMods(partyMember1, fileName1);

	partyMember2.setName(fileName2);
	statsTagsMods(partyMember2, fileName2);

	cout << endl << "Select a boos from the list bellow, and type it exactly as you see it" << endl;

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
	statsTagsMods(boss, bossFile);

	Turn turn;
	turn.setPartyMember(partyMember);
	turn.printPartyMember(partyMember);

}

void statsTagsMods(Character partyMember, string fileName) {
	ifstream inFile;
	string openFile;
	int attack, speed, defense, block, hp;
	openFile = fileName + "_stats.txt";
	inFile.open(openFile);
	int arr1[5];
	if (inFile.is_open()) {
		for (int i = 0; i < 5; ++i) {
			inFile >> arr1[i];
		}
	}
	else {
		cout << "unable to open " + openFile << endl;
		exit(1);
	}
	inFile.close();

	attack = arr1[0];
	speed = arr1[1];
	defense = arr1[2];
	block = arr1[3];
	hp = arr1[4];

	partyMember.setAttack(attack);
	partyMember.setSpeed(speed);
	partyMember.setDefense(defense);
	partyMember.setBlock(block);
	partyMember.setHp(hp);
	vector<string> tags;
	openFile = fileName + "_Tags.txt";
	inFile.open(openFile);
	if (inFile.is_open()) {
		string line;
		while (getline(inFile, line)) {
			if (line.size() == 0) {
				break;
			}
			tags.push_back(line);
		}
		inFile.close();
	}
	else {
		cout << "unable to open " + openFile << endl;
		exit(1);
	}
	vector<pair<string, int>> tagsAndMods;
	inFile.open("mods.txt");
	if (inFile.is_open()) {
		pair<string, int> input;
		while (inFile >> input.first >> input.second) {
			tagsAndMods.push_back(input);
		}
		inFile.close();
	}
	partyMember.setTags(tags);

	int totalModVal = 0;
	for (auto d : tagsAndMods) {
		for (int i = 0; i < tags.size(); ++i) {
			if (tags[i] == d.first) {
				totalModVal += d.second;

			}
		}
	}
	partyMember.setMod(totalModVal);
	partyMember.printStats();
}

void setBasePower(Turn turn, string fileName) {
	ifstream inFile;
	string openFile;
}