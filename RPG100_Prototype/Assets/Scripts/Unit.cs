// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
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

    //public int startingAP;
    //public int currentAP;
    //public int maxAP;
    public int APGen;

    // First Attack Stats
    public string firstAttackName;
    public int firstAttackCost;
    public int firstAttackBP;
    public string firstAttackType;

    // Second Attack Stats
    public string secondAttackName;
    public int secondAttackCost;
    public int secondAttackBP;
    public string secondAttackType;

    // Third Attack Stats
    public string thirdAttackName;
    public int thirdAttackCost;
    public int thirdAttackBP;
    public string thirdAttackType;

    // Fourth Attack Stats
    public string fourthAttackName;
    public int fourthAttackCost;
    public int fourthAttackBP;
    public string AttackType;

    void Start()
    {
        isTurn = false;
        //startingAP = 0;
        //currentAP = startingAP;
    }

    public bool TakeDamage(int dmg) // Modify Current HP based on parameter
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    // Multiplier Modifier //
    public void setMult(int newVal) { multiplier = newVal; }

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
    public int SetDamage(int AttackBP, int enemyDefense)
    {
        damage = (2 * AttackBP * (attack / enemyDefense) + multiplier) + 2;
        Debug.Log(damage);
        return damage;
    }
}