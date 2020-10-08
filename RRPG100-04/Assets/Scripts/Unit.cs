// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public bool alive; 

    public int APGen;

    public int bonusDamage; 

    public GameObject tag1, tag2, tag3, tag4, tag5;

    public List<GameObject> tags = new List<GameObject>();

    public GameObject passiveItem1, passiveItem2;

    public List<GameObject> passiveItems = new List<GameObject>();


    void Start()
    {

    }



    // damage formula ==================================================================

    public int SetDamage(int AttackBP, int enemyDefense)
    {
        damage = 0;
        damage = bonusDamage + (2 * AttackBP * (attack / enemyDefense) + multiplier) + 2;
        //Debug.Log(damage);
        return damage;
    }

    //==================================================================================

}