// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text firstAttackNameText;
    public Text firstAttackBPText;
    public Text firstAttackCostText;
    public Text secondAttackNameText;
    public Text secondAttackBPText;
    public Text secondAttackCostText;
    public Text thirdAttackNameText;
    public Text thirdAttackBPText;
    public Text thirdAttackCostText;
    public Text fourthAttackNameText;
    public Text fourthAttackBPText;
    public Text fourthAttackCostText;

    public GameObject firstAttackTypeSprite;
    public GameObject secondAttackTypeSprite;
    public GameObject thirdAttackTypeSprite;
    public GameObject fourthAttackTypeSprite;

    public Text hpText;

    public GameObject _BattleSystem;

    public void SetHUD(Unit unit)
    {
        SetHP(unit.GetComponent<Unit>().currentHP.ToString());

    }

    public void SetAttackHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        firstAttackNameText.text = unit.firstAttackName;
        firstAttackBPText.text = "Base Power: " + unit.firstAttackBP.ToString();
        firstAttackCostText.text = unit.firstAttackCost.ToString();
        firstAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.firstAttackTypeIcon;

        secondAttackNameText.text = unit.secondAttackName;
        secondAttackBPText.text = "Base Power: " + unit.secondAttackBP.ToString();
        secondAttackCostText.text = unit.secondAttackCost.ToString();
        secondAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.secondAttackTypeIcon;

        thirdAttackNameText.text = unit.thirdAttackName;
        thirdAttackBPText.text = "Base Power: " + unit.thirdAttackBP.ToString();
        thirdAttackCostText.text = unit.thirdAttackCost.ToString();
        thirdAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.thirdAttackTypeIcon;

        fourthAttackNameText.text = unit.fourthAttackName;
        fourthAttackBPText.text = "Base Power: " + unit.fourthAttackBP.ToString();
        fourthAttackCostText.text = unit.fourthAttackCost.ToString();
        fourthAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.fourthAttackTypeIcon;

    }
    public void SetHP(string hp)
    {
        hpText.text = hp;
    }
}