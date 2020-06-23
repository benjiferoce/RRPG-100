// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPointSpawn: MonoBehaviour
{
    public GameObject CombatPointPrefab;
    void Start()
    {
        int spawnPoints = Random.Range(1, 4);

        for(int i = 0; i < spawnPoints; ++i)
        {
            var position = new Vector3(Random.Range(-100, 100), 1, Random.Range(-100, 100));
            Instantiate(CombatPointPrefab, position, Quaternion.identity);
        }
    }
}
