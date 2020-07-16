using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrCarCola : MonoBehaviour
{
    public GameObject _DrCarCola;
    public GameObject _BattleSystem;
    public int _turnCount;
   //public int turnActivated;
   //public bool isFirstAttackReady;
   //public bool isSecondAttackReady;
   //public bool isThirdAttackReady;
   //public bool isFourthAttackReady;

    public Text ActionText;

    void Start()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        
    }

    void Update()
    {
        //_turnCount = _BattleSystem.GetComponent<BattleSystem>().turnCount;
     
    }
    public void FirstAttackEffect()
    {
       
    }

    public void SecondAttackEffect()
    {
        return; 
    }

    public void ThirdAttackEffect()
    {

    }

    public void FourthAttackEffect()
    {
        _BattleSystem = GameObject.FindGameObjectWithTag("BattleSystem");
        _BattleSystem.GetComponent<BattleSystem>().CurrentTurnCharacter.GetComponent<Unit>().damage += 10;
        //Debug.Log("Hi Cola");
    }
}

