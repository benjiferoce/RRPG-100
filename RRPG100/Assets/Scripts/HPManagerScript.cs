// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManagerScript : MonoBehaviour
{
    public GameObject _battleSystem;
    public Text hpText1;
    public Text hpText2;
    public Text hpText3;

    void Update()
    {
        hpText1.text = _battleSystem.GetComponent<BattleSystem>().playerPrefab.GetComponent<Unit>().currentHP.ToString();
        hpText2.text = _battleSystem.GetComponent<BattleSystem>().player2Prefab.GetComponent<Unit>().currentHP.ToString();
        hpText3.text = _battleSystem.GetComponent<BattleSystem>().player3Prefab.GetComponent<Unit>().currentHP.ToString();

        //Debug.Log("playerPrefab HP: " + hpText1);
    }
}
