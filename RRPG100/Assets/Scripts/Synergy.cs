// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Synergy : MonoBehaviour
{
    public List<String> Tags1 = new List<String>();
    public List<String> Tags2 = new List<String>();
    public List<String> Tags3 = new List<String>();
    public List<String> AllTags = new List<String>();
    public GameObject _party;

    public int bonus; 

    public Text synergyText;
    public Text synergyDesc;

    public List<string> synergy = new List<String>();

    void Start()
    {
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag1);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag2);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag3);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag4);
        Tags1.Add(_party.GetComponent<PartyScript>().Character1.GetComponent<Unit>().tag5);

        BuildAllTagsList(Tags1);

        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag1);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag2);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag3);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag4);
        Tags2.Add(_party.GetComponent<PartyScript>().Character2.GetComponent<Unit>().tag5);

        BuildAllTagsList(Tags2);


        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag1);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag2);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag3);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag4);
        Tags3.Add(_party.GetComponent<PartyScript>().Character3.GetComponent<Unit>().tag5);

        BuildAllTagsList(Tags3);

        CleanAllTagsList(AllTags);

    }

    void BuildAllTagsList(List<string> _Tags)
    {
        for(int i = 0; i < _Tags.Count; ++i)
            AllTags.Add(_Tags[i]);
    }

    void CleanAllTagsList(List<string> _Tags)
    {
        for (int i = 0; i < _Tags.Count; ++i)
        {
            if (_Tags[i] == "")
            {
                _Tags.Remove(_Tags[i]);
            }
        }
    }
}
