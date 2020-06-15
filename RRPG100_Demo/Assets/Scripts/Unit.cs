using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int attack;
    public int defense;
    public int multiplier;
    public int maxHP;
    public int currentHP;
    public int speed;
    public string charType;
    public int turnNum;
    public bool isTurn;

    public int startingAP;
    public int APGen;

    // First Attack Stats
    public string firstAttackName;
    public int firstAttackCost;
    public int firstAttackBP;

    // Second Attack Stats
    public string secondAttackName;
    public int secondAttackCost;
    public int secondAttackBP;

    // Third Attack Stats
    public string thirdAttackName;
    public int thirdAttackCost;
    public int thirdAttackBP;

    // Fourth Attack Stats
    public string fourthAttackName;
    public int fourthAttackCost;
    public int fourthAttackBP;
    void Start()
    {
        isTurn = false;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}
