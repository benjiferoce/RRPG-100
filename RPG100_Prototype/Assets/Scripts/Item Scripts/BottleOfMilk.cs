// RRPG-100 Battle System Script
// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BottleOfMilk : MonoBehaviour
{
    public BattleSystem battleSystem;
    public BattleHUD battleHUD;
    public List<GameObject> partyMembers = new List<GameObject>();
    public GameObject playerUsing;
    public Text actionText;

    public void ItemEffect()
    {
        TrackCurrentPlayer();
        Debug.Log("Enter ItemEffect() in BottleOfMilk Script");
        playerUsing.GetComponent<Unit>().currentHP += 25;
        actionText.text = playerUsing.GetComponent<Unit>().unitName + " used " + this.GetComponent<Item>().itemName + " and " + this.GetComponent<Item>().itemDescription;

        /*
        for(int i = 0; i < battleSystem.characterList.Count; ++i)
        {
            
            if(battleSystem.GetComponent<BattleSystem>().turn == playerUsing.GetComponent<Unit>().turnNum)
            {
                
                Debug.Log(playerUsing.GetComponent<Unit>().unitName + "'s Turn/use Item");
                playerUsing.GetComponent<Unit>().currentHP += 10;
            }
            else { return; }
        }
        */
    }

    public void TrackCurrentPlayer()
    {
        for (int i = 0; i < battleSystem.characterList.Count; ++i)
        {

            if (battleSystem.GetComponent<BattleSystem>().turn == battleSystem.GetComponent<BattleSystem>().characterList[i].GetComponent<Unit>().turnNum)
            {
                playerUsing = battleSystem.GetComponent<BattleSystem>().characterList[i];
            }
        }
    }
}
