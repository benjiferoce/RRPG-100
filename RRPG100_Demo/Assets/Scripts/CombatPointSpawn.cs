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
            var position = new Vector3(Random.Range(-12, 12), 1, Random.Range(-12, 12));
            Instantiate(CombatPointPrefab, position, Quaternion.identity);
        }
    }
}
