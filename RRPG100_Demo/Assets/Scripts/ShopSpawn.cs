using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawn : MonoBehaviour
{
    public GameObject ShopPrefab;
   
    void Start()
    {
        var position = new Vector3(Random.Range(-12, 12), 1, Random.Range(-12, 12));
        Instantiate(ShopPrefab, position, Quaternion.identity);
    }
}
