﻿// RRPG-100 Battle System Script
// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //public GameObject PassiveItem1;

    public int startingAP;
    public int currentAP;
    public int maxAP;
    public int APGenRate;

    public Text APNum;
    public Slider apSlider;


    public int partyGold;

    void Start()
    {
        
        startingAP = 0;
        maxAP = 10;
        currentAP = startingAP;
        SetAPGenRate();
        apSlider.maxValue = maxAP;
        apSlider.value = currentAP;
        APNum.text = currentAP.ToString();
    }


    void Update()
    {

    }

    public void RemoveActiveItem(GameObject Item){ Item = null; }
    public void SetItemActive1(GameObject Item){ ActiveItem1 = Item; }
    public void SetItemActive2(GameObject Item) { ActiveItem2 = Item; }
    public void SetItemActive3(GameObject Item) { ActiveItem3 = Item; }
    public void SetItemActive4(GameObject Item) { ActiveItem4 = Item; }

    void SetAPGenRate()
    {
        APGenRate = Character1.GetComponent<Unit>().APGen + Character2.GetComponent<Unit>().APGen + Character3.GetComponent<Unit>().APGen;
    }

    public void SetPartyAP(int num)
    {
        currentAP += num;
    }

    public void SetPartyAPHUD()
    {
        apSlider.value = currentAP;
        APNum.text = currentAP.ToString();
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
