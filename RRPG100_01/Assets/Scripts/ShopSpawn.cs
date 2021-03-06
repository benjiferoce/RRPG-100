﻿// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawn : MonoBehaviour
{
    public GameObject ShopPrefab;
   
    void Start()
    {
        var position = new Vector3(Random.Range(-250, 250), 1, Random.Range(-250, 250));
        Instantiate(ShopPrefab, position, Quaternion.identity);
    }
}
