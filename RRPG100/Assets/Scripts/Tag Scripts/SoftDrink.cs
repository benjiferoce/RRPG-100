// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoftDrink : MonoBehaviour
{
    public GameObject _synergy;
    public GameObject _party;
    public GameObject _battleHUD; 

    public string tagType = "Soft Drink";
    public List<string> _pTags = new List<string>();
    public int xBonus;
    public int bonReq = 3; 
    public bool typeSyng = false; 
    void Start()
    {
        _synergy = GameObject.FindGameObjectWithTag("SynergyManager");
        _party = GameObject.FindGameObjectWithTag("Party");
        _battleHUD = GameObject.FindGameObjectWithTag("BattleHUD");

        for (int i = 0; i < _synergy.GetComponent<Synergy>().AllTags.Count; ++i)
        {
            if (_synergy.GetComponent<Synergy>().AllTags[i] == tagType)
            {
                _pTags.Add(_synergy.GetComponent<Synergy>().AllTags[i]);
            }
        }

        xBonus = _pTags.Count; 

        if(xBonus == bonReq)
        {
            typeSyng = true;
            _battleHUD.GetComponent<BattleHUD>().partySynergyTxt.text = 
            tagType + " Synergy " + "X" + bonReq.ToString() + " Bonus!";
        }
    }
}
