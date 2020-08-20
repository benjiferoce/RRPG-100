// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public Text partyMem1InfoTxtTags;
    public Text partyMem2InfoTxtTags;
    public Text partyMem3InfoTxtTags;
    //public Text partyMemRsvInfoTxtTags;

    public Text partySynergyTxt;
    public Text partySynergyDescTxt; 
    
    // public GameObject firstAttackTypeSprite;
    // public GameObject secondAttackTypeSprite;
    // public GameObject thirdAttackTypeSprite;
    // public GameObject fourthAttackTypeSprite;

    public Text hpText;

    public GameObject _BattleSystem;
    public GameObject _party;

    bool mem1InfoButt, mem2InfoButt, mem3InfoButt;

    public void SetHUD(Unit unit)
    {
        SetHP(unit.GetComponent<Unit>().currentHP.ToString());
        SetTagText();
    }

    void Start()
    {
        SetTagText();
        _party = GameObject.FindGameObjectWithTag("Party");
    }

    public void SetAttackHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        firstAttackNameText.text = unit.firstAttackName;
        firstAttackBPText.text = "Base Power: " + unit.firstAttackBP.ToString();
        firstAttackCostText.text = unit.firstAttackCost.ToString();
        //firstAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.firstAttackTypeIcon;

        secondAttackNameText.text = unit.secondAttackName;
        secondAttackBPText.text = "Base Power: " + unit.secondAttackBP.ToString();
        secondAttackCostText.text = unit.secondAttackCost.ToString();
       // secondAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.secondAttackTypeIcon;

        thirdAttackNameText.text = unit.thirdAttackName;
        thirdAttackBPText.text = "Base Power: " + unit.thirdAttackBP.ToString();
        thirdAttackCostText.text = unit.thirdAttackCost.ToString();
        //thirdAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.thirdAttackTypeIcon;

        fourthAttackNameText.text = unit.fourthAttackName;
        fourthAttackBPText.text = "Base Power: " + unit.fourthAttackBP.ToString();
        fourthAttackCostText.text = unit.fourthAttackCost.ToString();
        //fourthAttackTypeSprite.GetComponent<SpriteRenderer>().sprite = unit.fourthAttackTypeIcon;
    }

    public void SetHP(string hp)
    {
        hpText.text = hp;
    }

    public void SetTagText()
    {
        partyMem1InfoTxtTags.text = _party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag1 + "\n"
            + _party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag2 + "\n "
            + _party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag3 + "\n "
            + _party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag4 + "\n "
            + _party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag5;

        partyMem2InfoTxtTags.text = _party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag1 + "\n"
           + _party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag2 + "\n "
           + _party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag3 + "\n "
           + _party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag4 + "\n "
           + _party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag5;

        partyMem3InfoTxtTags.text = _party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag1 + "\n "
           + _party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag2 + "\n "
           + _party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag3 + "\n "
           + _party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag4 + "\n "
           + _party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag5;
    }

    public void OnParMem1InfButton()
    {
        mem1InfoButt = !mem1InfoButt;
        this.gameObject.SetActive(partyMem1InfoTxtTags);
    }

    public void OnParMem2InfButton()
    {
        mem2InfoButt = !mem2InfoButt;
        this.gameObject.SetActive(partyMem2InfoTxtTags);
    }

    public void OnParMem3InfButton()
    {
        mem3InfoButt = !mem3InfoButt;
        this.gameObject.SetActive(partyMem3InfoTxtTags);
    }
}