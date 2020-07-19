// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitID; 
    public string unitName;
    public int unitNumber; 
    public int attack;
    public int defense;
    public int multiplier;
    public int maxHP;
    public int currentHP;
    public int speed;
    public string charType;
    public int turnNum;
    public bool isTurn;
    public int damage;
    public int block;
    public int dodge;

    public string style;

    public int APGen;

    public Sprite CharacterHUDSprite; 

    public GameObject _BattleSystem; 

    // First Attack Stats
    public string firstAttackName;
    public int firstAttackCost;
    public int firstAttackBP;
    public string firstAttackType;
    public string firstAttackEffect;

    // Second Attack Stats
    public string secondAttackName;
    public int secondAttackCost;
    public int secondAttackBP;
    public string secondAttackType;
    public string secondAttackEffect;
  
    // Third Attack Stats
    public string thirdAttackName;
    public int thirdAttackCost;
    public int thirdAttackBP;
    public string thirdAttackType;
    public string thirdAttackEffect;
 
    // Fourth Attack Stats
    public string fourthAttackName;
    public int fourthAttackCost;
    public int fourthAttackBP;
    public string fourthAttackType;
    public string fourthAttackEffect;
 
    public int bonusDamage; 

    public GameObject PassiveItem1;
    public GameObject PassiveItem2;

    public bool newRun; 

    void Start()
    {
        //damage = 0;
        bonusDamage = 0;
        isTurn = false;
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
    }

    void Update()
    {

    }

    public bool TakeDamage(int dmg) // Modify Current HP based on parameter
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public int SetDamage(int AttackBP, int enemyDefense)
    {
        damage = 0;
        damage = bonusDamage + (2 * AttackBP * (attack / enemyDefense) + multiplier) + 2;
        Debug.Log(damage);
        return damage;
    }

    // Multiplier Modifier //
    public void setMult(int newVal) { multiplier = newVal; }

    public void RemovePassiveItem(GameObject Item) { Item = null; }
    public void SetItemActive1(GameObject Item) { PassiveItem1 = Item; }
    public void SetItemActive2(GameObject Item) { PassiveItem2 = Item; }

    // AP Methods //=====================================================================
    //public void generateTurnAP(){ currentAP += APGen;}
    //public void setAP(int newVal){currentAP += newVal;}
    public void setAPGen(int newVal) { APGen += newVal; }
    //public void setMaxAP(int newVal){APGen += newVal;}

    //==================================================================================

    public void setFirstAttackCost(int newVal) { firstAttackCost = newVal; }
    public void setFirstAttackBP(int newVal) { firstAttackBP = newVal; }
    public void setSecondAttackCost(int newVal) { firstAttackCost = newVal; }
    public void setSecondAttackBP(int newVal) { firstAttackBP = newVal; }
    public void setThirdAttackCost(int newVal) { firstAttackCost = newVal; }
    public void setThirdAttackBP(int newVal) { firstAttackBP = newVal; }
    public void setFourthAttackCost(int newVal) { firstAttackCost = newVal; }
    public void setFourthAttackBP(int newVal) { firstAttackBP = newVal; }

    // damage formula ==================================================================
    
}