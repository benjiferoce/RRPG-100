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

    public Sprite physicalIcon;
    public Sprite rangedIcon;
    public Sprite healIcon;
    public Sprite magicIcon;

    public Text hpText;

    //public GameObject ActiveMenu;
    //public GameObject PassiveMenu;

    //public GameObject ItemMenuHUD;
    //public bool viewItems;
    //public Slider apSlider;

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

        secondAttackNameText.text = unit.secondAttackName;
        secondAttackBPText.text = "Base Power: " + unit.secondAttackBP.ToString();
        secondAttackCostText.text = unit.secondAttackCost.ToString();

        thirdAttackNameText.text = unit.thirdAttackName;
        thirdAttackBPText.text = "Base Power: " + unit.thirdAttackBP.ToString();
        thirdAttackCostText.text = unit.thirdAttackCost.ToString();

        fourthAttackNameText.text = unit.fourthAttackName;
        fourthAttackBPText.text = "Base Power: " + unit.fourthAttackBP.ToString();
        fourthAttackCostText.text = unit.fourthAttackCost.ToString();

    }
    public void SetHP(string hp)
    {
        hpText.text = hp;
    }

    /*
    public void activeItemTab()
    {
        ActiveMenu.GetComponent<SpriteRenderer>().sortingOrder = 0;
        PassiveMenu.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    public void passiveItemTab()
    {
        ActiveMenu.GetComponent<SpriteRenderer>().sortingOrder = -1;
        PassiveMenu.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

    public void ItemMenuButton()
    {
        viewItems = !viewItems;
        ItemMenuHUD.gameObject.SetActive(viewItems);
    }
    */
}

