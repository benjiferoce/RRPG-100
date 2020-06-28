using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour
{

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject CharacterReserve;

    public int startingAP;
    public int currentAP;
    public int maxAP;

    public int partyGold;

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddGoldToParty(int amount)
    {
        partyGold += amount;
    }

    public void SubtractGoldFromParty(int amount)
    {
        partyGold -= amount;
    }
}

