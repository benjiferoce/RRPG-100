// RRPG-100 Battle System Script
// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsHUD : MonoBehaviour
{
    public PartyScript party;
    public GameObject ItemManager;
    public Text item1Name;

    public bool ActiveTab;
    public bool PassiveTab;

    public GameObject ActiveMenu;
    public GameObject PassiveMenu;
    public GameObject UseItemButton;
    public GameObject ItemMenuHUD;
    public bool viewItems;
    public List<GameObject> partyMembers = new List<GameObject>();
    void Start()
    {
        ActiveTab = true;
        PassiveTab = false;
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in allCharacters)
        {
            partyMembers.Add(character);
        }
        //SetActiveItemHUD();
        
    }

    void Update()
    {
        if(ActiveTab == true)
        {
            UseItemButton.SetActive(true);
        }
        else
        {
            UseItemButton.SetActive(false);
        }
        if(ActiveTab == true)
        {
            SetActiveItemHUD();
        }
        if(PassiveTab == true)
        {
            SetPassiveItemHUD();
        }
    }

    public void SetActiveItemHUD()
    {
        item1Name.text = party.ActiveItem1.GetComponent<Item>().itemName;
        
    }

    public void SetPassiveItemHUD()
    {
        item1Name.text = party.PassiveItem1.GetComponent<Item>().itemName;

    }

    public void activeItemTab()
    {
        ActiveTab = true;
        PassiveTab = false;
        ActiveMenu.GetComponent<SpriteRenderer>().sortingOrder = 0;
        PassiveMenu.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    public void passiveItemTab()
    {
        ActiveTab = false;
        PassiveTab = true;
        ActiveMenu.GetComponent<SpriteRenderer>().sortingOrder = -1;
        PassiveMenu.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

    public void ItemMenuButton()
    {
        viewItems = !viewItems;
        ItemMenuHUD.gameObject.SetActive(viewItems);
    }

    public void SetActiveItemButton()
    {
        if (ActiveTab == true)
        {
            if(party.ActiveItem1.GetComponent<Item>().itemName == "Bottle Of Milk"){ItemManager.GetComponentInChildren<BottleOfMilk>().ItemEffect();}
            //if(party.ActiveItem1.GetComponent<Item>().itemName == "Jug Of Milk") {ItemManager.GetComponentInChildren<JugOfMilk>().ItemEffect();}
        }
    }
}
