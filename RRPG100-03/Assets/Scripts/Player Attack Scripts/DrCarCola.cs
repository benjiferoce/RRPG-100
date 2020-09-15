// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrCarCola : MonoBehaviour
{
    public GameObject _DrCarCola;
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
        ActionText.text = "First Attack Effect";
    }

    public void SecondAttackEffect()
    {
        ActionText.text = "Second Attack Effect";
    }

    public void ThirdAttackEffect()
    {
        ActionText.text = "Third Attack Effect";
    }

    public void FourthAttackEffect()
    {
        if (_BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitID == "DrCarCola")
        {
            _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().bonusDamage =
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().speed / 10;
        }
        else
        {
            return;
        }
    }

    public void SetFirstCharSynergy()
    {

    }
    public void SetSecondCharSynergy()
    {

    }
    public void SetThirdCharSynergy()
    {

    }
}

