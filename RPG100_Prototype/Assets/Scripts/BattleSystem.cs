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
    public Text turnText;
    public Text actionText;
    public Text APNum; 
    public Slider apSlider;

    public int startingAP;
    public int currentAP;
    public int maxAP;

    public bool chooseAttack; 

    public int turn = 0;
    public int turnCount;

    public List<GameObject> characterList = new List<GameObject>();

    Unit playerUnit;
    Unit enemyUnit;

    public Unit SelectedEnemy;
    public bool EnemySelected;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        turnCount = 0; 
        playerPrefab = Party.GetComponent<PartyScript>().Character1;
        player2Prefab = Party.GetComponent<PartyScript>().Character2;
        player3Prefab = Party.GetComponent<PartyScript>().Character3;

        startingAP = 0;
        maxAP = 10;
        currentAP = startingAP;
        apSlider.maxValue = maxAP;
        apSlider.value = currentAP;
        APNum.text = currentAP.ToString();
        state = BattleState.START;
        EnemySelected = false; 
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        SetTurn();
        //Debug.Log(turn);
        if (turn == 4)
        {      // Resets Turn to 0 
            turn = 0;
        }

        if (playerPrefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = playerPrefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(playerPrefab);
        }
        if (player2Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = player2Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(player2Prefab);
        }
        if (player3Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            turnText.text = player3Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(player3Prefab);
        }

        if (playerPrefab.GetComponent<Unit>().currentHP <= 0 && player2Prefab.GetComponent<Unit>().currentHP <= 0 && player3Prefab.GetComponent<Unit>().currentHP <= 0)
        {
            state = BattleState.LOST;
            EndBattle();
        }
    }

    IEnumerator SetupBattle()       // Sets Starting HP, Instantiates players at battlestations, and sets the player HUDs
    {
        playerPrefab.GetComponent<Unit>().currentHP = playerPrefab.GetComponent<Unit>().maxHP;
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        player2Prefab.GetComponent<Unit>().currentHP = player2Prefab.GetComponent<Unit>().maxHP;
        GameObject player2GO = Instantiate(player2Prefab, player2BattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        player3Prefab.GetComponent<Unit>().currentHP = player3Prefab.GetComponent<Unit>().maxHP;
        GameObject player3GO = Instantiate(player3Prefab, player3BattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerPrefab.GetComponent<Unit>());

        playerHUD2.SetHUD(player2Prefab.GetComponent<Unit>());

        playerHUD3.SetHUD(player3Prefab.GetComponent<Unit>());

        SortTurns();

        enemyHUD.SetHUD(enemyUnit);

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
            characterList.Sort(delegate (GameObject a, GameObject b) {
                return (a.GetComponent<Unit>().speed).CompareTo(b.GetComponent<Unit>().speed);
            });
        }

        characterList.Reverse();

        for (int i = 0; i < characterList.Count; ++i)
        {
            characterList[i].GetComponent<Unit>().turnNum = i;

            if (characterList[i].GetComponent<Unit>().turnNum == 0)
            {
                characterList[i].tag = "First";
            }
            if (characterList[i].GetComponent<Unit>().turnNum == 1)
            {
                characterList[i].tag = "Second";
            }
            if (characterList[i].GetComponent<Unit>().turnNum == 2)
            {
                characterList[i].tag = "Third";
            }
            if (characterList[i].GetComponent<Unit>().turnNum == 3)
            {
                characterList[i].tag = "Fourth";
            }
        }
    }

    void SetTurn()
    {
        if (turn == 0)
        {
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("First");
            if (currentTurnPlayer.GetComponent<Unit>().charType == "Player")
            {
                state = BattleState.PLAYERTURN;
                playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());



            }
            else if (currentTurnPlayer.GetComponent<Unit>().charType == "Enemy")
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();
            }
            turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
        if (turn == 1)
        {
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Second");
            if (currentTurnPlayer.GetComponent<Unit>().charType == "Player")
            {
                state = BattleState.PLAYERTURN;
                playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());



            }
            else if (currentTurnPlayer.GetComponent<Unit>().charType == "Enemy")
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();
            }
            turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
        if (turn == 2)
        {
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Third");
            if (currentTurnPlayer.GetComponent<Unit>().charType == "Player")
            {
                state = BattleState.PLAYERTURN;
                playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());


            }
            else if (currentTurnPlayer.GetComponent<Unit>().charType == "Enemy")
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();

            }
            turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);
        }
        if (turn == 3)
        {
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Fourth");
            if (currentTurnPlayer.GetComponent<Unit>().charType == "Player")
            {
                state = BattleState.PLAYERTURN;
                playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());

            }
            else if (currentTurnPlayer.GetComponent<Unit>().charType == "Enemy")
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();


            }
            turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            //Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
    }

    // =============================================================Player Attack Methods=========================================================== //
    IEnumerator PlayerFirstAttack()
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].GetComponent<Unit>().turnNum == turn)
            {
                if (currentAP >= characterList[i].GetComponent<Unit>().firstAttackCost)
                {
                    
                    characterList[i].GetComponent<Unit>().SetDamage(characterList[i].GetComponent<Unit>().firstAttackBP,
                    enemyUnit.GetComponent<Unit>().defense);
                    bool isDead = enemyUnit.GetComponent<Unit>().TakeDamage(characterList[i].GetComponent<Unit>().damage);
                    actionText.text = characterList[i].GetComponent<Unit>().unitName + " used " + characterList[i].GetComponent<Unit>().firstAttackName + "!";
                    currentAP -= characterList[i].GetComponent<Unit>().firstAttackCost;
                    apSlider.value = currentAP;
                    APNum.text = currentAP.ToString();
                    Debug.Log(characterList[i].GetComponent<Unit>().damage);

                    enemyHUD.SetHP(enemyUnit.GetComponent<Unit>().currentHP.ToString());

                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                }
                else
                {
                    Debug.Log(characterList[i].GetComponent<Unit>().unitName + "Can't Afford " + characterList[i].GetComponent<Unit>().firstAttackName);
                }
            }  
        }
    }
    

    IEnumerator PlayerSecondAttack()
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].GetComponent<Unit>().turnNum == turn)
            {
                if (currentAP >= characterList[i].GetComponent<Unit>().secondAttackCost)
                {
                    characterList[i].GetComponent<Unit>().SetDamage(characterList[i].GetComponent<Unit>().secondAttackBP,
                    enemyUnit.GetComponent<Unit>().defense);
                    bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().damage);
                    actionText.text = characterList[i].GetComponent<Unit>().unitName + "used " + characterList[i].GetComponent<Unit>().secondAttackName + "!";
                    currentAP -= characterList[i].GetComponent<Unit>().secondAttackCost;
                    apSlider.value = currentAP;
                    APNum.text = currentAP.ToString();
                    Debug.Log(characterList[i].GetComponent<Unit>().damage);

                    enemyHUD.SetHP(enemyUnit.currentHP.ToString());

                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                }
                else
                {
                    Debug.Log(characterList[i].GetComponent<Unit>().unitName + "Can't Afford " + characterList[i].GetComponent<Unit>().secondAttackName);
                }
            }
        }
    }

    IEnumerator PlayerThirdAttack()
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].GetComponent<Unit>().turnNum == turn)
            {
                if (currentAP >= characterList[i].GetComponent<Unit>().thirdAttackCost)
                {
                    characterList[i].GetComponent<Unit>().SetDamage(characterList[i].GetComponent<Unit>().thirdAttackBP,
                    enemyUnit.GetComponent<Unit>().defense);
                    bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().damage);
                    actionText.text = characterList[i].GetComponent<Unit>().unitName + "used " + characterList[i].GetComponent<Unit>().thirdAttackName + "!";
                    currentAP -= characterList[i].GetComponent<Unit>().thirdAttackCost;
                    apSlider.value = currentAP;
                    APNum.text = currentAP.ToString();
                    Debug.Log(characterList[i].GetComponent<Unit>().damage);
                    enemyHUD.SetHP(enemyUnit.currentHP.ToString());

                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                }
                else
                {
                    Debug.Log(characterList[i].GetComponent<Unit>().unitName + "Can't Afford " + characterList[i].GetComponent<Unit>().thirdAttackName);
                }
            }
        }
    }

    IEnumerator PlayerFourthAttack()
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].GetComponent<Unit>().turnNum == turn)
            {
                if (currentAP >= characterList[i].GetComponent<Unit>().fourthAttackCost)
                {
                    characterList[i].GetComponent<Unit>().SetDamage(characterList[i].GetComponent<Unit>().fourthAttackBP,
                    enemyUnit.GetComponent<Unit>().defense);
                    bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().damage);
                    actionText.text = characterList[i].GetComponent<Unit>().unitName + "used " + characterList[i].GetComponent<Unit>().fourthAttackName + "!";
                    currentAP -= characterList[i].GetComponent<Unit>().fourthAttackCost;
                    apSlider.value = currentAP;
                    APNum.text = currentAP.ToString();
                    Debug.Log(characterList[i].GetComponent<Unit>().damage);

                    enemyHUD.SetHP(enemyUnit.currentHP.ToString());

                    yield return new WaitForSeconds(2f);

                    if (isDead)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
                }
                else
                {
                    Debug.Log(characterList[i].GetComponent<Unit>().unitName + "Can't Afford " + characterList[i].GetComponent<Unit>().fourthAttackName);
                }
            }
        }
    }

    // ========================================================================================================================================== //

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

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {
        turnText.text = enemyPrefab.GetComponent<Unit>().unitName + "'s Turn!";

        int playerToAttack = UnityEngine.Random.Range(0, 3);
        //Debug.Log("Random Number is" + playerToAttack);

        if (playerToAttack == 0)
        {
            if (playerPrefab.GetComponent<Unit>().currentHP > 0)
            {
                playerPrefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD.SetHP(playerPrefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
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
                player2Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD2.SetHP(player2Prefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
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
                player3Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD3.SetHP(player3Prefab.GetComponent<Unit>().currentHP.ToString());
                turn = turn + 1;
            }
            else
            {
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }

    }

    public void OnFirstAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerFirstAttack());
    }

    public void OnSecondAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerSecondAttack());
    }

    public void OnThirdAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerThirdAttack());
    }

    public void OnFourthAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerFourthAttack());
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

    void ResortTurns(GameObject killedPlayer)
    {

    }

    public void AttackButton()
    {
        chooseAttack = !chooseAttack;
        playerAttacksHUD.gameObject.SetActive(chooseAttack);
    }

    public void SelectEnemyToAttack()
    {
        Debug.Log("Hit");
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.GetComponent<Unit>().charType == "Enemy")
                {
                    EnemySelected = true;
                    SelectedEnemy = hit.transform.gameObject.GetComponent<Unit>();
                }
            }
            else
            {
                Debug.Log("Invalid Target");
            }
            
        }
    }
}
