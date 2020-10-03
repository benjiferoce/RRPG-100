// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackEffectsManager : MonoBehaviour
{
    public GameObject _BattleSystem;
    public GameObject Character;
    public string UnitID;

    void Update()
    {
        
        UnitID = _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitID; 
    }

    public void CallFirstAttackEffect()
    {
        switch (UnitID)
        {
            case "DrCarCola":
                GetComponent<DrCarCola>().FirstAttackEffect();
                break;
            case "LemonLimeLad":
                GetComponent<LemonLimeLad>().FirstAttackEffect();
                break;
            case "RootBeerBoy":
                GetComponent<RootBeerBoy>().FirstAttackEffect();
                break;
            case "CurtiseIceBlower":
                GetComponent<CurtisIceBlower>().FirstAttackEffect();
                break;
            case "AlbinoGator":
                GetComponent<AlbinoGator>().FirstAttackEffect();
                break;
        }
    }

    public void CallSecondAttackEffect()
    {
        switch (UnitID)
        {
            case "DrCarCola":
                GetComponent<DrCarCola>().SecondAttackEffect();
                break;
            case "LemonLimeLad":
                GetComponent<LemonLimeLad>().SecondAttackEffect();
                break;
            case "RootBeerBoy":
                GetComponent<RootBeerBoy>().SecondAttackEffect();
                break;
            case "CurtiseIceBlower":
                GetComponent<CurtisIceBlower>().SecondAttackEffect();
                break;
            case "AlbinoGator":
                GetComponent<AlbinoGator>().SecondAttackEffect();
                break;
        }
    }

    public void CallThirdAttackEffect()
    {
        switch (UnitID)
        {
            case "DrCarCola":
                GetComponent<DrCarCola>().ThirdAttackEffect();
                break;
            case "LemonLimeLad":
                GetComponent<LemonLimeLad>().ThirdAttackEffect();
                break;
            case "RootBeerBoy":
                GetComponent<RootBeerBoy>().ThirdAttackEffect();
                break;
            case "CurtiseIceBlower":
                GetComponent<CurtisIceBlower>().ThirdAttackEffect();
                break;
            case "AlbinoGator":
                GetComponent<AlbinoGator>().ThirdAttackEffect();
                break;
        }
    }

    public void CallFourthAttackEffect()
    {
        switch (UnitID)
        {
            case "DrCarCola":
               GetComponent<DrCarCola>().FourthAttackEffect();
                break;
            case "LemonLimeLad":
                GetComponent<LemonLimeLad>().FourthAttackEffect();
                break;
            case "RootBeerBoy":
                GetComponent<RootBeerBoy>().FourthAttackEffect();
                break;
            case "CurtiseIceBlower":
                GetComponent<CurtisIceBlower>().FourthAttackEffect();
                break;
            case "AlbinoGator":
                GetComponent<AlbinoGator>().FourthAttackEffect();
                break;
        }
    }
}
