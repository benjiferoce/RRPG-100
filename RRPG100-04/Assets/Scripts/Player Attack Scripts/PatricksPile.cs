// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatricksPile : MonoBehaviour
{
    public GameObject _PatricksPile;
    public GameObject _BattleSystem;
    public Text ActionText;

    void Start()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        ActionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<Text>();
    }

    void Update()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        ActionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<Text>();
    }
    public void FirstAttackEffect()
    {

    }

    public void SecondAttackEffect()
    {

    }

    public void ThirdAttackEffect()
    {


    }

    public void FourthAttackEffect()
    {

    }
}
