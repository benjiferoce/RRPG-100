using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrCarCola : MonoBehaviour
{
    public GameObject _DrCarCola;
    public GameObject _BattleSystem;
   
   //public int turnActivated;
   //public bool isFirstAttackReady;
   //public bool isSecondAttackReady;
   //public bool isThirdAttackReady;
   //public bool isFourthAttackReady;

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
        return; 
    }

    public void SecondAttackEffect()
    {
        return; 
    }

    public void ThirdAttackEffect()
    {
        return;             
    }

    public void FourthAttackEffect()
    {
        if (_BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().unitID == "DrCarCola")
        {
            _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().bonusDamage =
            _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().speed / 10;
        }
        else
        {
            return;
        }
    }
}

