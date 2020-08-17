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
    void Update()
    {
        //Debug.Log("Attack Effects Manager: Current Turn Character: " +
        //_BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitName);
    }

    public void SetFirstAttackButton(Unit unit){
        if(unit.unitID == "DrCarCola"){unit.GetComponent<DrCarCola>().FirstAttackEffect();}
        if(unit.unitID == "LemonLimeLad"){unit.GetComponent<LemonLimeLad>().FirstAttackEffect();}
        if(unit.unitID == "RootBeerBoy"){unit.GetComponent<RootBeerBoy>().FirstAttackEffect();}
    }
    public void SetSecondAttackButton(Unit unit)
    {
        if (unit.unitID == "DrCarCola") { unit.GetComponent<DrCarCola>().SecondAttackEffect(); }
        if (unit.unitID == "LemonLimeLad") { unit.GetComponent<LemonLimeLad>().SecondAttackEffect(); }
        if (unit.unitID == "RootBeerBoy") { unit.GetComponent<RootBeerBoy>().SecondAttackEffect(); }
    }
    public void SetThirdAttackButton(Unit unit)
    {
        if (unit.unitID == "DrCarCola") { unit.GetComponent<DrCarCola>().ThirdAttackEffect(); }
        if (unit.unitID == "LemonLimeLad") { unit.GetComponent<LemonLimeLad>().ThirdAttackEffect(); }
        if (unit.unitID == "RootBeerBoy") { unit.GetComponent<RootBeerBoy>().ThirdAttackEffect(); }
    }
    public void SetFourthAttackButton(Unit unit)
    {
        if (unit.unitID == "DrCarCola") { unit.GetComponent<DrCarCola>().FourthAttackEffect(); }
        if (unit.unitID == "LemonLimeLad") { unit.GetComponent<LemonLimeLad>().FourthAttackEffect(); }
        if (unit.unitID == "RootBeerBoy") { unit.GetComponent<RootBeerBoy>().FourthAttackEffect(); }
    }
}
