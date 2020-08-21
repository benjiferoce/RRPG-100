// RRPG-100 Battle System Script
// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject Party;
    public GameObject CurrentTurnCharacter;
    public GameObject playerPrefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform player2BattleStation;
    public Transform player3BattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD playerHUD2;
    public BattleHUD playerHUD3;
    public BattleHUD enemyHUD;
    public BattleHUD playerAttacksHUD;
    public GameObject AttacksHUD;

    public GameObject BattleHUD; 

    public int startingAP;
    public int currentAP;
    public int maxAP;
    public int apGen;
    public Text APNum;
    public Slider apSlider;

    public Text turnText;
    public Text actionText;
    public Text enemyHPText;
    public Text attackEffectDescText;

    public bool chooseAttack;
    public bool onEnemyHit = false; 

    public GameObject AttackEffectsManager;

    public int turn = 0;
    public int turnCount;

    public List<GameObject> characterList = new List<GameObject>();

    Unit playerUnit;
    Unit enemyUnit;

    public Unit SelectedEnemy;
    public bool EnemySelected;

    public BattleState state;

    public int agents;

    bool mem1InfoButt, mem2InfoButt, mem3InfoButt;
    public GameObject partyMeminfo1, partyMemInfo2, partyMemInfo3;

    void Start()
    {
        BattleHUD.GetComponent<BattleHUD>().SetTagText();
        turnCount = 0;
        playerPrefab = Party.GetComponent<PartyScript>().Character1;
        player2Prefab = Party.GetComponent<PartyScript>().Character2;
        player3Prefab = Party.GetComponent<PartyScript>().Character3;

        playerPrefab.GetComponent<Unit>().damage = 0;
        player2Prefab.GetComponent<Unit>().damage = 0;
        player3Prefab.GetComponent<Unit>().damage = 0;

        playerPrefab.GetComponent<Unit>().bonusDamage = 0;
        player2Prefab.GetComponent<Unit>().bonusDamage = 0;
        player3Prefab.GetComponent<Unit>().bonusDamage = 0;

        resetStats(Party.GetComponent<PartyScript>().Character1.GetComponent<Unit>());
        resetStats(Party.GetComponent<PartyScript>().Character2.GetComponent<Unit>());
        resetStats(Party.GetComponent<PartyScript>().Character3.GetComponent<Unit>());

        enemyPrefab.GetComponent<Unit>().currentHP = enemyPrefab.GetComponent<Unit>().maxHP;

        apGen = apGen + playerPrefab.GetComponent<Unit>().APGen + player2Prefab.GetComponent<Unit>().APGen + player3Prefab.GetComponent<Unit>().APGen;

        startingAP = 0;
        maxAP = 10;
        currentAP = startingAP;
        apSlider.maxValue = maxAP;
        apSlider.value = currentAP;
        APNum.text = currentAP.ToString();

        state = BattleState.START;

        EnemySelected = false;

        StartCoroutine(SetupBattle());

        UpdateTurnNumbers(playerPrefab);
        UpdateTurnNumbers(player2Prefab);
        UpdateTurnNumbers(player3Prefab);
        UpdateTurnNumbers(enemyPrefab);
    }
    void Update()
    {
        Party.GetComponent<PartyScript>().currentAP = currentAP;
        SetTurn();

        SetPartyAPHUD();

        agents = characterList.Count;

        turnText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "'s turn!";

        enemyHPText.text = enemyPrefab.GetComponent<Unit>().currentHP.ToString();

        if (state == BattleState.PLAYERTURN) { playerAttacksHUD.SetAttackHUD(CurrentTurnCharacter.GetComponent<Unit>()); }

        //if(CurrentTurnCharacter.GetComponent<Unit>().charType == "Player"){ state = BattleState.PLAYERTURN; }

        if (turn == 4) { turn = 0; }

        if (playerPrefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = playerPrefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            //ResortTurns(playerPrefab);
        }
        if (player2Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = player2Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            //ResortTurns(player2Prefab);
        }
        if (player3Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = player3Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            //ResortTurns(player3Prefab);
        }

        if (playerPrefab.GetComponent<Unit>().currentHP <= 0 && player2Prefab.GetComponent<Unit>().currentHP <= 0 && player3Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            state = BattleState.LOST;
            EndBattle();
        }
    }
    IEnumerator SetupBattle()       // Sets Starting HP, Instantiates players at battlestations, and sets the player HUDs
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        GameObject player2GO = Instantiate(player2Prefab, player2BattleStation);
        GameObject player3GO = Instantiate(player3Prefab, player3BattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        SortTurns();
        //enemyHUD.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);
    }

    void SortTurns()    // Sorts combat turn order based on all Unit's speed value
    {
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in allCharacters)
        {
            characterList.Add(character);   // Adds all "Character" gameobjects to list "characterList
        }
        //Sorting list and check it count
        if (characterList.Count > 0)
        {
            characterList.Sort(delegate (GameObject a, GameObject b)
            {
                return (a.GetComponent<Unit>().speed).CompareTo(b.GetComponent<Unit>().speed);
            });
        }

        characterList.Reverse();

        for (int i = 0; i < characterList.Count; ++i)
        {
            characterList[i].GetComponent<Unit>().turnNum = i;
        }
    }

    void SetTurn()
    {
        if (turn == playerPrefab.GetComponent<Unit>().turnNum)
        {
            CurrentTurnCharacter = playerPrefab;
            state = BattleState.PLAYERTURN;
            playerAttacksHUD.SetAttackHUD(playerPrefab.GetComponent<Unit>());
        }
        if (turn == player2Prefab.GetComponent<Unit>().turnNum)
        {
            CurrentTurnCharacter = player2Prefab;
            state = BattleState.PLAYERTURN;
            playerAttacksHUD.SetAttackHUD(player2Prefab.GetComponent<Unit>());
        }
        if (turn == player3Prefab.GetComponent<Unit>().turnNum)
        {
            CurrentTurnCharacter = player3Prefab;
            state = BattleState.PLAYERTURN;
            playerAttacksHUD.SetAttackHUD(player3Prefab.GetComponent<Unit>());
        }
        if (turn == enemyPrefab.GetComponent<Unit>().turnNum)
        {
            CurrentTurnCharacter = enemyPrefab;
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    void UpdateTurnNumbers(GameObject Character)
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].GetComponent<Unit>().unitName == Character.GetComponent<Unit>().unitName)
            {
                Character.GetComponent<Unit>().turnNum = characterList[i].GetComponent<Unit>().turnNum;
            }
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            turnText.text = "Enemy Defeated!";
        }
        else if (state == BattleState.LOST)
        {
            turnText.text = "Game Over...";
        }
    }

    public void OnEndTurnButton()
    {

        if (turn == characterList.Count() - 1)
        {
            setPartyAP();
        }
        if (state != BattleState.PLAYERTURN) return;
        turn = turn + 1;
        turnCount = turnCount + 1;
        attackEffectDescText.text = " ";
        actionText.text = " ";
    }

    public void setPartyAP()
    {
        for (int i = 0; i < characterList.Count(); ++i)
        {
            if (currentAP < maxAP)
            {
                currentAP += characterList[i].GetComponent<Unit>().APGen;
                apSlider.value = currentAP;
                APNum.text = currentAP.ToString();
            }
            else
            {
                currentAP = maxAP;
                APNum.text = maxAP.ToString();
            }
        }
    }

    public void SetPartyAPHUD()
    {
        apSlider.value = currentAP;
        APNum.text = currentAP.ToString();
    }

    void EnemyTurn()
    {
        int playerToAttack = UnityEngine.Random.Range(0, 3);

        //Debug.Log("Random Number is" + playerToAttack);

        if (playerToAttack == 0)
        {
            if (playerPrefab.GetComponent<Unit>().currentHP > 0)
            {

                playerPrefab.GetComponent<Unit>().TakeDamage(enemyPrefab.GetComponent<Unit>().damage);
                actionText.text = enemyPrefab.GetComponent<Unit>().unitName + " attacked " + playerPrefab.GetComponent<Unit>().unitName + " for " + enemyUnit.damage + " damage!";
                //playerHUD.SetHP(playerPrefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
                turnCount = turnCount + 1;
            }
            else
            {
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }

        if (playerToAttack == 1)
        {
            if (player2Prefab.GetComponent<Unit>().currentHP > 0)
            {

                player2Prefab.GetComponent<Unit>().TakeDamage(enemyPrefab.GetComponent<Unit>().damage);
                actionText.text = enemyPrefab.GetComponent<Unit>().unitName + " attacked " + player2Prefab.GetComponent<Unit>().unitName + " for " + enemyUnit.damage + " damage!";
                //playerHUD2.SetHP(player2Prefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
                turnCount = turnCount + 1;
            }
            else
            {
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }

        if (playerToAttack == 2)
        {
            if (player3Prefab.GetComponent<Unit>().currentHP > 0)
            {

                player3Prefab.GetComponent<Unit>().TakeDamage(enemyPrefab.GetComponent<Unit>().damage);
                actionText.text = enemyPrefab.GetComponent<Unit>().unitName + " attacked " + player3Prefab.GetComponent<Unit>().unitName + " for " + enemyUnit.damage + " damage!";
                // playerHUD3.SetHP(player3Prefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
                turnCount = turnCount + 1;
            }
            else
            {
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }
    }

    // =============================================================Player Attack Methods=========================================================== //

    IEnumerator PlayerFirstAttack()
    {
        AttackEffectsManager.GetComponent<AttackEffectsManager>().CallFirstAttackEffect();
        attackEffectDescText.text = CurrentTurnCharacter.GetComponent<Unit>().firstAttackEffect;
        CurrentTurnCharacter.GetComponent<Unit>().SetDamage(CurrentTurnCharacter.GetComponent<Unit>().firstAttackBP,
        enemyPrefab.GetComponent<Unit>().defense);

        bool isDead = enemyPrefab.GetComponent<Unit>().TakeDamage(CurrentTurnCharacter.GetComponent<Unit>().damage);

        actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + " used " + "'" + CurrentTurnCharacter.GetComponent<Unit>().firstAttackName
        + "'" + " on " + enemyPrefab.GetComponent<Unit>().unitName + " for " + CurrentTurnCharacter.GetComponent<Unit>().damage + " Damage!";

        enemyHUD.SetHP(enemyPrefab.GetComponent<Unit>().currentHP.ToString());

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
    }



    IEnumerator PlayerSecondAttack()
    {
        AttackEffectsManager.GetComponent<AttackEffectsManager>().CallSecondAttackEffect();
        attackEffectDescText.text = CurrentTurnCharacter.GetComponent<Unit>().secondAttackEffect;
        CurrentTurnCharacter.GetComponent<Unit>().SetDamage(CurrentTurnCharacter.GetComponent<Unit>().secondAttackBP,
        enemyPrefab.GetComponent<Unit>().defense);

        bool isDead = enemyPrefab.GetComponent<Unit>().TakeDamage(CurrentTurnCharacter.GetComponent<Unit>().damage);

        actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + " used " + "'" + CurrentTurnCharacter.GetComponent<Unit>().secondAttackName
        + "'" + " on " + enemyPrefab.GetComponent<Unit>().unitName + " for " + CurrentTurnCharacter.GetComponent<Unit>().damage + " Damage!";

        enemyHUD.SetHP(enemyPrefab.GetComponent<Unit>().currentHP.ToString());

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
    }

    IEnumerator PlayerThirdAttack()
    {
        AttackEffectsManager.GetComponent<AttackEffectsManager>().CallThirdAttackEffect();
        attackEffectDescText.text = CurrentTurnCharacter.GetComponent<Unit>().thirdAttackEffect;
        CurrentTurnCharacter.GetComponent<Unit>().SetDamage(CurrentTurnCharacter.GetComponent<Unit>().thirdAttackBP,
        enemyPrefab.GetComponent<Unit>().defense);

        bool isDead = enemyPrefab.GetComponent<Unit>().TakeDamage(CurrentTurnCharacter.GetComponent<Unit>().damage);

        actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + " used " + "'" + CurrentTurnCharacter.GetComponent<Unit>().thirdAttackName
        + "'" + " on " + enemyPrefab.GetComponent<Unit>().unitName + " for " + CurrentTurnCharacter.GetComponent<Unit>().damage + " Damage!";

        enemyHUD.SetHP(enemyPrefab.GetComponent<Unit>().currentHP.ToString());

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
    }

    IEnumerator PlayerFourthAttack()
    {


        AttackEffectsManager.GetComponent<AttackEffectsManager>().CallFourthAttackEffect();
        attackEffectDescText.text = CurrentTurnCharacter.GetComponent<Unit>().fourthAttackEffect;
        CurrentTurnCharacter.GetComponent<Unit>().SetDamage(CurrentTurnCharacter.GetComponent<Unit>().fourthAttackBP,
        enemyPrefab.GetComponent<Unit>().defense);

        bool isDead = enemyPrefab.GetComponent<Unit>().TakeDamage(CurrentTurnCharacter.GetComponent<Unit>().damage);

        actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + " used " + "'" + CurrentTurnCharacter.GetComponent<Unit>().fourthAttackName
        + "'" + " on " + enemyPrefab.GetComponent<Unit>().unitName + " for " + CurrentTurnCharacter.GetComponent<Unit>().damage + " Damage!";

        enemyHUD.SetHP(enemyPrefab.GetComponent<Unit>().currentHP.ToString());

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
    }
    

    // ========================================================================================================================================== //

    public void AttackButton()
    {
        chooseAttack = !chooseAttack;
        playerAttacksHUD.gameObject.SetActive(chooseAttack);
    }

    public void OnFirstAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        ChargeFirstAttack();

        if (CurrentTurnCharacter.GetComponent<Unit>().firstAttackCharged == true &&
        currentAP >= CurrentTurnCharacter.GetComponent<Unit>().firstAttackCost)
        {
            firstAttackAP(); 
            StartCoroutine(PlayerFirstAttack());
        }
        else

            if (Party.GetComponent<PartyScript>().currentAP < CurrentTurnCharacter.GetComponent<Unit>().firstAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "Can't Afford " + CurrentTurnCharacter.GetComponent<Unit>().firstAttackName;
            return;
        }
        if (CurrentTurnCharacter.GetComponent<Unit>().firstAttackCharged == false &&
            Party.GetComponent<PartyScript>().currentAP >= CurrentTurnCharacter.GetComponent<Unit>().firstAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "'s " + CurrentTurnCharacter.GetComponent<Unit>().firstAttackName +
            " will take " + CurrentTurnCharacter.GetComponent<Unit>().firstAttackTurnDelay + " turns " + "to charge!";
            UnityEngine.Debug.Log("Not Ready");
            return;
        }
    }

    public void OnSecondAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        ChargeSecondAttack();

        if (CurrentTurnCharacter.GetComponent<Unit>().secondAttackCharged == true &&
        currentAP >= CurrentTurnCharacter.GetComponent<Unit>().secondAttackCost)
        {
            secondAttackAP();
            StartCoroutine(PlayerSecondAttack());
        }
        else

            if (Party.GetComponent<PartyScript>().currentAP < CurrentTurnCharacter.GetComponent<Unit>().secondAttackCost)
        {
            CurrentTurnCharacter.GetComponent<Unit>().secondAttackReady = -1;
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "Can't Afford " + CurrentTurnCharacter.GetComponent<Unit>().secondAttackName;
            return;
        }
        if (CurrentTurnCharacter.GetComponent<Unit>().secondAttackCharged == false &&
            Party.GetComponent<PartyScript>().currentAP >= CurrentTurnCharacter.GetComponent<Unit>().secondAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "'s " + CurrentTurnCharacter.GetComponent<Unit>().secondAttackName +
            " will take " + CurrentTurnCharacter.GetComponent<Unit>().secondAttackTurnDelay + " turns " + "to charge!";
            UnityEngine.Debug.Log("Not Ready");
            return;
        }
    }

    public void OnThirdAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        ChargeThirdAttack();

        if (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCharged == true &&
        currentAP >= CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCost)
        {
            thirdAttackAP();
            StartCoroutine(PlayerThirdAttack());
        }
        else
        {

            if (Party.GetComponent<PartyScript>().currentAP < CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCost)
            {
                CurrentTurnCharacter.GetComponent<Unit>().thirdAttackReady = -1;
                actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "Can't Afford " + CurrentTurnCharacter.GetComponent<Unit>().thirdAttackName;
                return;
            }
        }
        if (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCharged == false &&
            Party.GetComponent<PartyScript>().currentAP >= CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "'s " + CurrentTurnCharacter.GetComponent<Unit>().thirdAttackName +
            " will take " + CurrentTurnCharacter.GetComponent<Unit>().thirdAttackTurnDelay + " turns " + "to charge!";
            UnityEngine.Debug.Log("Not Ready");
            return;
        }
    }

    public void OnFourthAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        ChargeFourthAttack();

        if (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCharged == true &&
        currentAP >= CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCost)
        {
            fourthAttackAP();
            StartCoroutine(PlayerFourthAttack());
        }
        else

            if (Party.GetComponent<PartyScript>().currentAP < CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "Can't Afford " + CurrentTurnCharacter.GetComponent<Unit>().fourthAttackName;
            return;
        }
        if (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCharged == false &&
            Party.GetComponent<PartyScript>().currentAP >= CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCost)
        {
            actionText.text = CurrentTurnCharacter.GetComponent<Unit>().unitName + "'s " + CurrentTurnCharacter.GetComponent<Unit>().fourthAttackName +
            " will take " + CurrentTurnCharacter.GetComponent<Unit>().fourthAttackTurnDelay + " turns " + "to charge!";
            UnityEngine.Debug.Log("Not Ready");
            return;
        }
    }

    public void OnParMem1InfButton()
    {
        mem1InfoButt = !mem1InfoButt;
        partyMeminfo1.SetActive(mem1InfoButt);
    }

    public void OnParMem2InfButton()
    {
        mem2InfoButt = !mem2InfoButt;
        partyMemInfo2.SetActive(mem2InfoButt);
    }

    public void OnParMem3InfButton()
    {
        mem3InfoButt = !mem3InfoButt;
        partyMemInfo3.SetActive(mem3InfoButt);
    }

    void resetStats(Unit unit)
    {
        unit.currentHP = unit.maxHP;
        unit.turnNum = 0;
    }

    public void ChargeFirstAttack()
    {
        if (CurrentTurnCharacter.GetComponent<Unit>().firstAttackTurnDelay == 0)
        {
            CurrentTurnCharacter.GetComponent<Unit>().firstAttackCharged = true;
            UnityEngine.Debug.Log("Ready");
        }
        else
        {
            if (CurrentTurnCharacter.GetComponent<Unit>().firstAttackReady == (CurrentTurnCharacter.GetComponent<Unit>().firstAttackTurnDelay * characterList.Count) + characterList.Count)
            {
                CurrentTurnCharacter.GetComponent<Unit>().firstAttackCharged = false;
                CurrentTurnCharacter.GetComponent<Unit>().firstAttackReady = (CurrentTurnCharacter.GetComponent<Unit>().firstAttackTurnDelay * characterList.Count) + characterList.Count;
            }
            else
            {
                CurrentTurnCharacter.GetComponent<Unit>().firstAttackCharged = true;
                CurrentTurnCharacter.GetComponent<Unit>().firstAttackReady = 0;
            }
        }
    }
    public void ChargeSecondAttack()
    {
        if (CurrentTurnCharacter.GetComponent<Unit>().secondAttackTurnDelay == 0)
        {
            CurrentTurnCharacter.GetComponent<Unit>().secondAttackCharged = true;
        }
        else
        {
            if (CurrentTurnCharacter.GetComponent<Unit>().secondAttackReady != (CurrentTurnCharacter.GetComponent<Unit>().secondAttackTurnDelay * characterList.Count) + characterList.Count)
            {
                CurrentTurnCharacter.GetComponent<Unit>().secondAttackCharged = false;
                CurrentTurnCharacter.GetComponent<Unit>().secondAttackReady = (CurrentTurnCharacter.GetComponent<Unit>().secondAttackTurnDelay * characterList.Count) + characterList.Count;
            }
            else
            {
                CurrentTurnCharacter.GetComponent<Unit>().secondAttackCharged = true;
                CurrentTurnCharacter.GetComponent<Unit>().secondAttackReady = 0;
            }
        }
    }
    public void ChargeThirdAttack()
    {
        if (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackTurnDelay == 0 && Party.GetComponent<PartyScript>().currentAP >= CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCost)
        {
            CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCharged = true;
        }
        else
        {
            if (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackReady != (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackTurnDelay * characterList.Count) + characterList.Count)
            {
                CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCharged = false;
                CurrentTurnCharacter.GetComponent<Unit>().thirdAttackReady = (CurrentTurnCharacter.GetComponent<Unit>().thirdAttackTurnDelay * characterList.Count) + characterList.Count;
            }
            else
            {
                CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCharged = true;
                CurrentTurnCharacter.GetComponent<Unit>().thirdAttackReady = 0; 
            }
        }
    }
    public void ChargeFourthAttack()
    {
        if (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackTurnDelay == 0)
        {
            CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCharged = true;
        }
        else
        {
            if (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackReady != (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackTurnDelay * characterList.Count) + characterList.Count)
            {
                CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCharged = false;
                CurrentTurnCharacter.GetComponent<Unit>().fourthAttackReady = (CurrentTurnCharacter.GetComponent<Unit>().fourthAttackTurnDelay * characterList.Count) + characterList.Count;
            }
            else
            {
                CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCharged = true;
                CurrentTurnCharacter.GetComponent<Unit>().fourthAttackReady = 0;
            }
        }
    }
    public void firstAttackAP() { currentAP = currentAP - CurrentTurnCharacter.GetComponent<Unit>().firstAttackCost; }
    public void secondAttackAP() { currentAP = currentAP - CurrentTurnCharacter.GetComponent<Unit>().secondAttackCost; }
    public void thirdAttackAP() { currentAP = currentAP - CurrentTurnCharacter.GetComponent<Unit>().thirdAttackCost; }
    public void fourthAttackAP() { currentAP = currentAP - CurrentTurnCharacter.GetComponent<Unit>().fourthAttackCost; }
}