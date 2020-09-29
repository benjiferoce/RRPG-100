// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Synergy : MonoBehaviour
{
    public List<String> Tags1 = new List<String>();
    public List<String> Tags2 = new List<String>();
    public List<String> Tags3 = new List<String>();
    public List<String> AllTags = new List<String>();
    public GameObject _party;
    public List<string> synergyList = new List<string>();
    public List<int> synergyBonus = new List<int>();
    public int synergyCount;
    public GameObject _battleSystem; 
    public int bonus;
    public GameObject battleHUD;
    public Text synergyText;
    public Text synergyDesc;


    void Start()
    {
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag1);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag2);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag3);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag4);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag5);

        Tags1 = Tags1.Distinct().ToList();
        CleanAllTagsList(Tags1);
        BuildAllTagsList(Tags1);
        
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag1);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag2);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag3);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag4);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag5);

        Tags2 = Tags2.Distinct().ToList();
        CleanAllTagsList(Tags2);
        BuildAllTagsList(Tags2);
        
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag1);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag2);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag3);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag4);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag5);
 
        Tags3 = Tags3.Distinct().ToList();
        CleanAllTagsList(Tags3);
        BuildAllTagsList(Tags3);
        CheckTagsForSynergy();
        battleHUD.GetComponent<BattleHUD>().SetPartySynergyText();
    }

    void BuildAllTagsList(List<string> _Tags)
    {
        for(int i = 0; i < _Tags.Count; ++i)
            AllTags.Add(_Tags[i]);
    }

    void CleanAllTagsList(List<string> _Tags)
    {
        UnityEngine.Debug.Log(_Tags.Count);
        for (int i = 0; i < _Tags.Count; ++i)
        {
            if (_Tags[i] == "")
            {
                _Tags.Remove(_Tags[i]);
            }
        }
    }

    public void CheckTagsForSynergy()
    {
        for(int i = 0; i < AllTags.Count; ++i)
        {
            string _tag = AllTags[i];
            SetSynergyList(_tag);
        }
        AllTags = AllTags.Distinct().ToList();
        for(int i = 0; i < AllTags.Count; ++i)
        {
            string _tag = AllTags[i];
            SetSynergyBonus(_tag);
        }
    }

    public void SetSynergyList(string _tag)
    {
        switch (_tag)
        {
            case "Soft Drink":
                ++GetComponent<SoftDrink>().xBonus;
                //GetComponent<SoftDrink>().SetSynergy();
                break;
            case "Cold":
                ++GetComponent<Cold>().xBonus;
                //GetComponent<Cold>().SetSynergy();
                break;
            case "Army":
                ++GetComponent<Army>().xBonus;
                //GetComponent<Army>().SetSynergy();
                break;
            case "Beefy":
                ++GetComponent<Beefy>().xBonus;
                //GetComponent<Beefy>().SetSynergy();
                break;
            case "Bird":
                ++GetComponent<Bird>().xBonus;
                //GetComponent<Bird>().SetSynergy();
                break;
            case "Doctor":
                ++GetComponent<Doctor>().xBonus;
                //GetComponent<Doctor>().SetSynergy();
                break;
            case "Dog":
                ++GetComponent<Dog>().xBonus;
                //GetComponent<Dog>().SetSynergy();
                break;
            case "Fish":
                ++GetComponent<Fish>().xBonus;
                //GetComponent<Fish>().SetSynergy();
                break;
            case "Gun":
                ++GetComponent<Gun>().xBonus;
                //GetComponent<Gun>().SetSynergy();
                break;
            case "Plaid":
                ++GetComponent<Plaid>().xBonus;
                //GetComponent<Plaid>().SetSynergy();
                break;
            case "Reptile":
                ++GetComponent<Reptile>().xBonus;
                //GetComponent<Reptile>().SetSynergy();
                break;
            case "Sticky":
                ++GetComponent<Sticky>().xBonus;
                //GetComponent<Sticky>().SetSynergy();
                break;
            case "Sweet":
                ++GetComponent<Sweet>().xBonus;
                //GetComponent<Sweet>().SetSynergy();
                break;
            case "Team":
                ++GetComponent<Team>().xBonus;
                //GetComponent<Team>().SetSynergy();
                break;
        }
    }
    public void SetSynergyBonus(string _tag)
    {
        switch (_tag)
        {
            case "Soft Drink":
                //++GetComponent<SoftDrink>().xBonus;
                GetComponent<SoftDrink>().SetSynergy();
                break;
            case "Cold":
                //++GetComponent<Cold>().xBonus;
                GetComponent<Cold>().SetSynergy();
                break;
            case "Army":
                //++GetComponent<Army>().xBonus;
                GetComponent<Army>().SetSynergy();
                break;
            case "Beefy":
                //++GetComponent<Beefy>().xBonus;
                GetComponent<Beefy>().SetSynergy();
                break;
            case "Bird":
                //++GetComponent<Bird>().xBonus;
                GetComponent<Bird>().SetSynergy();
                break;
            case "Doctor":
                //++GetComponent<Doctor>().xBonus;
                GetComponent<Doctor>().SetSynergy();
                break;
            case "Dog":
                //++GetComponent<Dog>().xBonus;
                GetComponent<Dog>().SetSynergy();
                break;
            case "Fish":
                //++GetComponent<Fish>().xBonus;
                GetComponent<Fish>().SetSynergy();
                break;
            case "Gun":
                //++GetComponent<Gun>().xBonus;
                GetComponent<Gun>().SetSynergy();
                break;
            case "Plaid":
                //++GetComponent<Plaid>().xBonus;
                GetComponent<Plaid>().SetSynergy();
                break;
            case "Reptile":
                //++GetComponent<Reptile>().xBonus;
                GetComponent<Reptile>().SetSynergy();
                break;
            case "Sticky":
                //++GetComponent<Sticky>().xBonus;
                GetComponent<Sticky>().SetSynergy();
                break;
            case "Sweet":
                //++GetComponent<Sweet>().xBonus;
                GetComponent<Sweet>().SetSynergy();
                break;
            case "Team":
                //++GetComponent<Team>().xBonus;
                GetComponent<Team>().SetSynergy();
                break;
        }
    }
}
