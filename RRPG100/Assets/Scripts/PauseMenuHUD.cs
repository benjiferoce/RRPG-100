// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenuHUD : MonoBehaviour
{
    public GameObject _BattleSystem;

    public GameObject _pauseMenuHUD; 

    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    public Text bioText;
    public Text numberText;
    public Text hpText;
    public Text apText; 
    public Text ATKText;
    public Text DEFText;
    public Text SPDText;
    public Text BLKText;
    public Text DDGText; 
    public Text StyleText;
    public Text TagsText;

    public Sprite charSprite; 

    public bool gamePaused;

    void Update()
    {
        SetChars();
    }

    public void PauseMenuButton()
    {
        gamePaused = !gamePaused;
        _pauseMenuHUD.gameObject.SetActive(gamePaused);
    }

    public void SetChars()
    {
        char1 = _BattleSystem.GetComponent<BattleSystem>().playerPrefab;
        char2 = _BattleSystem.GetComponent<BattleSystem>().player2Prefab;
        char3 = _BattleSystem.GetComponent<BattleSystem>().player3Prefab;
    }
}
