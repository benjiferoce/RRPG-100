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
    public Slider hpSlider; 

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
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
