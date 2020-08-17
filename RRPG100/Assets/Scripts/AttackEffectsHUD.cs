// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackEffectsHUD : MonoBehaviour
{
    public BattleSystem _BattleSystem;

    public Text attackDescText;

    public void SetFirstAttackText()
    {
        attackDescText.text = _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().firstAttackEffect;
    }

    public void SetSecondAttackText()
    {
        attackDescText.text = _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().secondAttackEffect;
    }

    public void SetThirdAttackText()
    {
        attackDescText.text = _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().thirdAttackEffect;
    }

    public void SetFourthAttackText()
    {
        attackDescText.text = _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().fourthAttackEffect;
    }
}
