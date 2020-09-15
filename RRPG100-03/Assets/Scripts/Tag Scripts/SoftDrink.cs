// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
public class SoftDrink : MonoBehaviour
{
    public GameObject _synergy;
    public GameObject _party;
    public GameObject _battleHUD;
    public int xBonus = 0; 
    public string tagType = "Soft Drink";

    public void SetSynergy()
    { 
        _synergy.GetComponent<Synergy>().synergyList.Add(tagType + " X" + xBonus);
    }
}
