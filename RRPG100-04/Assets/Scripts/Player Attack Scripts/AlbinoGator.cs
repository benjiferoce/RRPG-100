// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbinoGator : MonoBehaviour
{
    public GameObject _AlbinoGator;
    public GameObject _BattleSystem;
    public Text ActionText;

    void Start()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        ActionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<Text>();
    }

    void Update()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        ActionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<Text>();
    }
    public void FirstAttackEffect()
    { 

    }

    public void SecondAttackEffect()
    {
 
    }

    public void ThirdAttackEffect()
    {
        if (_BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitID == "AlbinoGator")
        {
            _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().bonusDamage =
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().defense / 10;
        }
        else
        {
            return;
        }
        
    }

    public void FourthAttackEffect()
    {

    }
}
