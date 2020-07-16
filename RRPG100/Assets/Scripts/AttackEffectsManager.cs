// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackEffectsManager : MonoBehaviour
{
    public GameObject _BattleSystem;
    public GameObject Character;
    void Update()
    {
        Debug.Log("Attack Effects Manager: Current Turn Character: " + _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitName);
    }

    public void SetFirstAttackButton(Unit unit)
    {
        if(unit.unitID == "DrCarCola")
        {
            unit.GetComponent<DrCarCola>().FirstAttackEffect();
        }
        else { Debug.Log("Not Cola"); }
    }
}
