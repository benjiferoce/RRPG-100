using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform player2BattleStation;
    public Transform player3BattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public Text turnText;

    public int turn = 0;

    public List<GameObject> characterList = new List<GameObject>();

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state; 
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject player2GO = Instantiate(player2Prefab, player2BattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject player3GO = Instantiate(player3Prefab, player3BattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        SortTurns();
        SetTurn();
        
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

    }

    void Update()
    {
        if(turn == 5)
        {
            turn = 0;
        }
        Debug.Log(turn);
    }

    void SortTurns()
    {
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in allCharacters)
        {
            characterList.Add(character);
        }
        //Sorting list and check it count
        if (characterList.Count > 0)
        {
            characterList.Sort(delegate (GameObject a, GameObject b) {
                return (a.GetComponent<Unit>().speed).CompareTo(b.GetComponent<Unit>().speed);
            });
        }

        characterList.Reverse();

        for(int i = 0; i < characterList.Count; ++i)
        {
            characterList[i].GetComponent<Unit>().turnNum = i;
        }
    }

    void SetTurn()
    {
        for(int i = 0; i <= characterList.Count + 1; ++i)
        {
            if (turn == characterList[i].GetComponent<Unit>().turnNum && characterList[i].GetComponent<Unit>().charType == "Player")
            {
                state = BattleState.PLAYERTURN;
                playerHUD.SetHUD(characterList[i].GetComponent<Unit>());
                characterList[i].GetComponent<Unit>().isTurn = true;

            }
            
            if(turn == characterList[i].GetComponent<Unit>().turnNum && characterList[i].GetComponent<Unit>().charType == "Enemy")
            {
                state = BattleState.ENEMYTURN;
                enemyHUD.SetHUD(characterList[i].GetComponent<Unit>());
                StartCoroutine(EnemyTurn());
            }
              
            
           
            turnText.text = characterList[i].GetComponent<Unit>().unitName + "'s Turn";
        }
        
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        Debug.Log(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            ++turn;
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            turnText.text = "Enemy Defeated!";
        }else if(state == BattleState.LOST)
        {
            turnText.text = "Game Over...";
        }
    }

    void PlayerTurn()
    {
        
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            ++turn;
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }
}
