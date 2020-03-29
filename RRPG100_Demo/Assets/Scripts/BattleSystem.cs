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
    public BattleHUD playerHUD2;
    public BattleHUD playerHUD3;
    public BattleHUD enemyHUD;
    public Text turnText;

    public int turn = 0;
    public int nextTurn;

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
        playerPrefab.GetComponent<Unit>().currentHP =  playerPrefab.GetComponent<Unit>().maxHP;
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        player2Prefab.GetComponent<Unit>().currentHP =  player2Prefab.GetComponent<Unit>().maxHP;
        GameObject player2GO = Instantiate(player2Prefab, player2BattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        player3Prefab.GetComponent<Unit>().currentHP =  player3Prefab.GetComponent<Unit>().maxHP;
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

    void Update()
    {
        SetTurn();
        Debug.Log(turn);
        if(turn == 4){
            turn = 0;
        }
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

            if(characterList[i].GetComponent<Unit>().turnNum == 0){
                characterList[i].tag = "First";
            }
            if(characterList[i].GetComponent<Unit>().turnNum == 1){
                characterList[i].tag = "Second";
            }
            if(characterList[i].GetComponent<Unit>().turnNum == 2){
                characterList[i].tag = "Third";
            }
            if(characterList[i].GetComponent<Unit>().turnNum == 3){
                characterList[i].tag = "Fourth";
            }
        }
    }

    void SetTurn()
    {
        if(turn == 0){
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("First");
            if(currentTurnPlayer.GetComponent<Unit>().charType == "Player"){
            state = BattleState.PLAYERTURN;
            
            
        }else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            
        }
        turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
        if(turn == 1){
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Second");
            if(currentTurnPlayer.GetComponent<Unit>().charType == "Player"){
            state = BattleState.PLAYERTURN;
            
            
        }else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            
        }
        turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
        if(turn == 2){
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Third");
            if(currentTurnPlayer.GetComponent<Unit>().charType == "Player"){
            state = BattleState.PLAYERTURN;
           
            
        }else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            
        }
        turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
            Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);
        }
        if(turn == 3){
            GameObject currentTurnPlayer = GameObject.FindGameObjectWithTag("Fourth");
            if(currentTurnPlayer.GetComponent<Unit>().charType == "Player"){
            state = BattleState.PLAYERTURN;
            
        }else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            
        }
        turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
        Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

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

    void EnemyTurn()
    {
        turnText.text = enemyPrefab.GetComponent<Unit>().unitName + "'s Turn!";
        
        int playerToAttack = UnityEngine.Random.Range(0, 3);
        Debug.Log("Random Number is" + playerToAttack);

        if(playerToAttack == 0){
            playerPrefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
            playerHUD.SetHP(playerPrefab.GetComponent<Unit>().currentHP);
            
            turn = turn + 1;
        }

        if(playerToAttack == 1){
            player2Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
            playerHUD2.SetHP(playerPrefab.GetComponent<Unit>().currentHP);
            
            turn = turn + 1;
        }

        if(playerToAttack == 2){
            player3Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
            playerHUD3.SetHP(playerPrefab.GetComponent<Unit>().currentHP);
            
            turn = turn + 1;
        }
        
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnEndTurnButton(){
        if (state != BattleState.PLAYERTURN) return;
        turn = turn + 1;
    }
}
