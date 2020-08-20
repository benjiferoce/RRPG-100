// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text firstAttackText;
    public Text secondAttackText;
    public Text thirdAttackText;
    public Text fourthAttackText;
    public Sprite physicalIcon;
    public Sprite rangedIcon;
    public Sprite healIcon;
    public Sprite magicIcon;

    public Slider hpSlider;
    public Slider apSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        //apSlider.maxValue = unit.maxAP;
        //apSlider.value = unit.currentAP;
    }

    public void SetAttackHUD(Unit unit)
    {
        firstAttackText.text = unit.firstAttackName + "||" + unit.firstAttackCost + "||" + unit.firstAttackBP;
        secondAttackText.text = unit.secondAttackName + "||" + unit.secondAttackCost + "||" + unit.secondAttackBP;
        thirdAttackText.text = unit.thirdAttackName + "||" + unit.thirdAttackCost + "||" + unit.thirdAttackBP;
        fourthAttackText.text = unit.fourthAttackName + "||" + unit.fourthAttackCost + "||" + unit.fourthAttackBP;
    }
    public void SetHP(int hp)
    {
        hpSlider.value = hp; 
    }
}
