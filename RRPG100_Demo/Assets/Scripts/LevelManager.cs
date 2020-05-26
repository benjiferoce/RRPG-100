using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject EngageEnemyText;
    public GameObject EnterShopText;
    public GameObject Player;
    public bool hit;
  
    void Start()
    {
        hit = false;
        EngageEnemyText.SetActive(false);
        EnterShopText.SetActive(false);
    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("CombatPoint"))
        {
            EngageEnemyText.SetActive(true);
            hit = true;
        }

        if (other.gameObject.CompareTag("Shop"))
        {
            EnterShopText.SetActive(true);
            hit = true;
        }
    }

    public void LoadCombat()
    {
        SceneManager.LoadScene("SodaPortCombat");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("SodaPortShop");
    }
}
