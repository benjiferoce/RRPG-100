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
    public BattleHUD playerAttacksHUD;
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

    IEnumerator SetupBattle()       // Sets Starting HP, Instantiates players at battlestations, and sets the player HUDs
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
        //Debug.Log(turn);
        if(turn == 4){      // Resets Turn to 0 
            turn = 0;
        }

        if(playerPrefab.GetComponent<Unit>().currentHP <=0 ){
            turnText.text = playerPrefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(playerPrefab);
        }
        if(player2Prefab.GetComponent<Unit>().currentHP <=0 ){
            turnText.text = player2Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(player2Prefab);
        }
        if(player3Prefab.GetComponent<Unit>().currentHP <=0 ){
            turnText.text = player3Prefab.GetComponent<Unit>().unitName + "Has Been Killed!";
            ResortTurns(player3Prefab);
        }

        if(playerPrefab.GetComponent<Unit>().currentHP <=0 && player2Prefab.GetComponent<Unit>().currentHP <=0 && player3Prefab.GetComponent<Unit>().currentHP <=0){
            state = BattleState.LOST;
            EndBattle();
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
            playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());
            
            
            
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
            playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());



            }
            else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
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
            playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());


            }
            else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
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
            playerAttacksHUD.SetAttackHUD(currentTurnPlayer.GetComponent<Unit>());

            }
            else if(currentTurnPlayer.GetComponent<Unit>().charType == "Enemy"){
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            
            
        }
        turnText.text = currentTurnPlayer.GetComponent<Unit>().unitName + "'s Turn!";
        //Debug.Log(currentTurnPlayer.GetComponent<Unit>().unitName);

        }
    }

    IEnumerator PlayerFirstAttack()
    {
        for(int i = 0; i < characterList.Count; ++i){
            if(characterList[i].GetComponent<Unit>().turnNum == turn){
                bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().firstAttackBP);
                Debug.Log(characterList[i].GetComponent<Unit>().damage);

                enemyHUD.SetHP(enemyUnit.currentHP);

                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WON;
                    EndBattle();
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
                bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().secondAttackBP);
                Debug.Log(characterList[i].GetComponent<Unit>().damage);

                enemyHUD.SetHP(enemyUnit.currentHP);

                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WON;
                    EndBattle();
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
                bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().thirdAttackBP);
                Debug.Log(characterList[i].GetComponent<Unit>().damage);

                enemyHUD.SetHP(enemyUnit.currentHP);

                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WON;
                    EndBattle();
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
                bool isDead = enemyUnit.TakeDamage(characterList[i].GetComponent<Unit>().fourthAttackBP);
                Debug.Log(characterList[i].GetComponent<Unit>().damage);

                enemyHUD.SetHP(enemyUnit.currentHP);

                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
            }
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
        //Debug.Log("Random Number is" + playerToAttack);

        if(playerToAttack == 0){
            if(playerPrefab.GetComponent<Unit>().currentHP > 0){
                playerPrefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD.SetHP(playerPrefab.GetComponent<Unit>().currentHP);
                turn = turn + 1;
            }else{
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }

        if(playerToAttack == 1){
            if(player2Prefab.GetComponent<Unit>().currentHP > 0){
                player2Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD2.SetHP(player2Prefab.GetComponent<Unit>().currentHP);
                turn = turn + 1;
            }else{
                playerToAttack = UnityEngine.Random.Range(0, 3);
            }
        }

        if(playerToAttack == 2){
            if(player3Prefab.GetComponent<Unit>().currentHP > 0){
                player3Prefab.GetComponent<Unit>().TakeDamage(enemyUnit.damage);
                playerHUD3.SetHP(player3Prefab.GetComponent<Unit>().currentHP);
                turn = turn + 1;
            }else{
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

    public void OnEndTurnButton(){
        if (state != BattleState.PLAYERTURN) return;
        turn = turn + 1;
    }

    void ResortTurns(GameObject killedPlayer){

    }
}
