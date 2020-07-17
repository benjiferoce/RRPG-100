﻿// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JugOfMilk : MonoBehaviour
{
    public BattleSystem battleSystem;
    public BattleHUD battleHUD;
    public List<GameObject> partyMembers = new List<GameObject>();
    public GameObject playerUsing;
    public Text actionText;

    public void ItemEffect()
    {
        TrackCurrentPlayer();
        if (playerUsing.GetComponent<Unit>().currentHP + 50 > playerUsing.GetComponent<Unit>().maxHP)
        {
            int healedHP = playerUsing.GetComponent<Unit>().maxHP - playerUsing.GetComponent<Unit>().currentHP;
            playerUsing.GetComponent<Unit>().currentHP = playerUsing.GetComponent<Unit>().maxHP;
            actionText.text = playerUsing.GetComponent<Unit>().unitName + " used " + this.GetComponent<Item>().itemName + " and healed "
            + healedHP + " HP!";
        }
        else if (playerUsing.GetComponent<Unit>().currentHP == playerUsing.GetComponent<Unit>().maxHP)
        {
            actionText.text = playerUsing.GetComponent<Unit>().unitName + " is already at Max HP!";
        }
        else
        {
            playerUsing.GetComponent<Unit>().currentHP += 50;
            actionText.text = playerUsing.GetComponent<Unit>().unitName + " used " + this.GetComponent<Item>().itemName
            + " and healed 50 HP!";
        }
    }
    public void TrackCurrentPlayer()
    {
        for (int i = 0; i < battleSystem.characterList.Count; ++i)
        {
            if (battleSystem.turn == battleSystem.playerPrefab.GetComponent<Unit>().turnNum) { playerUsing = battleSystem.playerPrefab; }
            if (battleSystem.turn == battleSystem.player2Prefab.GetComponent<Unit>().turnNum) { playerUsing = battleSystem.player2Prefab; }
            if (battleSystem.turn == battleSystem.player3Prefab.GetComponent<Unit>().turnNum) { playerUsing = battleSystem.player3Prefab; }
        }
    }
}