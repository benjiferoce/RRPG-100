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
	void setName(string name) {
		_name = name;
	}
	void setAttack(int attack) {
		_attack = attack;
	}
	void setDefense(int defense) {
		_defense = defense;	
	}
	void setSpeed(int speed) {
		_speed = speed;
	}
	void setBlock(int block) {
		_block = block;
	}
	void setHp(int hp) {
		_hp = hp;
	}
	void setTags(vector<string> tags) {
		for (int i = 0; i < tags.size(); ++i) {
			_tags.push_back(tags[i]);
		}
	}
	void setMod(int mod) {
		_mod = mod;
	}
	//====================//

	//======= Accessors =====//
	string getName() {
		return _name;
	}
	int getAttack() {
		return _attack;
	}
	int getDefense() {
		return _defense;
	}
	int getSpeed() {
		return _speed;
	}
	int getBlock() {
		return _block;
	}
	int getHp() {
		return _hp;
	}
	vector<string> getTags() {
		return _tags;
	}
	int getMod() {
		return _mod;
	}
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
};

class Turn : public Character {
public:
	void setPartyMember(Character partyMember) {
		_partyMember = partyMember;
	}
	void printPartyMember(Character partyMember) {
		partyMember.printStats();
	}



private:
	Character _partyMember;
	bool _alive;

	vector<string> _attacks;
	int _bp;
};