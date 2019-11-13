#include <iostream>
#include <string>
#include <fstream>
#include <ctime>    
#include <cstdlib>
#include <list>
#include <vector>
#include <iterator>
#include <deque>
#include <utility>

using namespace std;
class Character {
public:
	//=======Set stats=====//
	void setName(string name) {_name = name;}
	void setAttack(int attack) {_attack = attack;}
	void setDefense(int defense) {_defense = defense;	}
	void setSpeed(int speed) {_speed = speed;}
	void setBlock(int block) {_block = block;}
	void setHp(int hp) {_hp = hp;}
	void setMod(int mod) {_mod = mod;}
	void setBp(int bp) {_bp = bp;}

	void setTags(vector<string> tags) {
		for (int i = 0; i < tags.size(); ++i) {
			_tags.push_back(tags[i]);
		}
	}
	void setAttacksAndBp(vector<pair<string, int>> attacksAndBp) {
		for (auto d : attacksAndBp) {
			_attacksAndBp = attacksAndBp;
		}
	}
	//====================//

	//======= Accessors =====//
	string getName() {return _name;}
	int getAttack() {return _attack;}
	int getDefense() {return _defense;}
	int getSpeed() {return _speed;}
	int getBlock() {return _block;}
	int getHp() {return _hp;}
	vector<string> getTags() {return _tags;}
	int getMod() {return _mod;}
	int getBp() {return _bp;}
	vector <pair<string, int>> getAttacksAndBp() {return _attacksAndBp;}
	//====================//
	void printStats() {			// Print Stats
		cout << "--------Name: "
			<< _name << "-------" << endl
			<< "Attack: " << _attack << endl
			<< "Defense: " << _defense << endl
			<< "Speed: " << _speed << endl
			<< "Block: " << _block << endl
			<< "hp: " << _hp << endl;
		cout << "MOD: +" << _mod << endl;
		cout << "BP: " << _bp << endl;
	}
	void printAttacksAndBp(Character& partyMember) {
		vector<pair<string, int>> attacksAndBp;
		attacksAndBp = partyMember.getAttacksAndBp();
		for (auto d : attacksAndBp) {
			cout << d.first << " " << d.second << endl;
		}
	}
	
	void statsTagsMods(Character& partyMember, string& fileName) {
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
		//partyMember.printStats();
	}

	void setAttacksAndBp(Character& partyMember, string& fileName) {
		ifstream inFile;
		string openFile;
		vector<pair<string, int>> attacksAndBp;
		openFile = partyMember.getName() + "_Attacks.txt";
		inFile.open(openFile);
		if (inFile.is_open()) {
			pair<string, int> input;
			while (inFile >> input.first >> input.second) {
				attacksAndBp.push_back(input);
			}
			inFile.close();
		}
		partyMember.setAttacksAndBp(attacksAndBp);
		string attackChoice;
		cout << "Select an Attack" << endl;
		partyMember.printAttacksAndBp(partyMember);
		cin >> attackChoice;
		for (auto d : attacksAndBp) {
			if (attackChoice == d.first) {
				partyMember.setBp(d.second);

			}
		}
	}
	//		Character Stat variables		//
private:
	string _name;
	int _attack;
	int _defense;
	int _speed;
	int _block;
	int _hp;
	vector<string> _tags;
	int _mod; 
	vector <pair<string, int>> _attacksAndBp;
	int _bp;
};