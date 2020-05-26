using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour
{
    public Unit Character1;
    public Unit Character2;
    public Unit Character3;
    public Unit CharacterReserve;

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
