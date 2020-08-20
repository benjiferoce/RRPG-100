// RRPG-100 Battle System Script
// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour
{

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject CharacterReserve;

    public GameObject ActiveItem1;
    public GameObject ActiveItem2;
    public GameObject ActiveItem3;
    public GameObject ActiveItem4;

    public GameObject PassiveItem1;

    public int startingAP;
    public int currentAP;
    public int maxAP;

    public int partyGold;

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddGoldToParty(int amount)
    {
        partyGold += amount;
    }

    public void SubtractGoldFromParty(int amount)
    {
        partyGold -= amount;
    }
}

