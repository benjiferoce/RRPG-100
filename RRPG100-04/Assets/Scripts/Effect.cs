// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Effect : MonoBehaviour
{
    public GameObject _BattleSystem;
    public GameObject AgentStat;
    public int duration, startTurn, endTurn; 
    public int buff;
    public bool active = false;
    public string effectType; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBuff(GameObject _AgentStat, int _duration, int _startTurn, int _endTurn)
    {
        AgentStat = _AgentStat;
        duration = _duration;
        startTurn = _startTurn;
        startTurn = _startTurn; 
    }

    public void SetDebuff()
    {

    }
}
