using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleHandler : MonoBehaviour
{
    private static BattleHandler instance;
    public static BattleHandler GetInstance(){
        return instance;
    }
    [SerializeField] private Transform pfCharacterBattle; //stores transformation data for prefab player
    [SerializeField] private Transform pfEnemyBattle; // stores transformation data for prefab enemy
    public GameObject battle_over_win; //canvas to be displayed on win
    public GameObject battle_over_lose; //canvas to be displayed on lose
    public GameObject pfSpell; //prefab for spell. not implemented 
    private CharacterBattle playerCharacterBattle; //battle script for player
    private CharacterBattle enemyCharacterBattle; //battle script for prefab enemy
    private CharacterBattle activeCharacterBattle; //keeps track of who's turn it is
    private State state; //either waiting on player or busy

    private enum State {
        WaitingForPlayer,
        Busy,
    }
    private void Awake() {
        instance = this;
    }

    //spawn characters, set who's turn it is to player at start of scene
    private void Start()
    {
        playerCharacterBattle = SpawnCharacter(true);
        enemyCharacterBattle = SpawnCharacter(false);

        SetActiveCharacterBattle(playerCharacterBattle);
        state = State.WaitingForPlayer;
    }
    private void Update()
    {
        if(state == State.WaitingForPlayer)
        {
            //sword attack
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Busy;
                playerCharacterBattle.Attack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
            }
            //magic attack
            if(Input.GetKeyDown(KeyCode.X))
            {   
                Instantiate(
                    pfSpell,
                    transform.position,
                    Quaternion.identity);
                
                state = State.Busy;
                playerCharacterBattle.Spell(enemyCharacterBattle, playerCharacterBattle, ()=> {
                    ChooseNextActiveCharacter();
                });
            }
            
        }
    
    }
    //spawns fighters with appropriate stats, health bars, and magic bars
    private CharacterBattle SpawnCharacter(bool isPlayerTeam){
        Vector3 position;
        if (isPlayerTeam) {
            position = new Vector3(-5,-1);
        }
        else{
            position = new Vector3(5,-1);
            pfCharacterBattle = pfEnemyBattle;
        }
        Transform characterTransform = Instantiate(pfCharacterBattle, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        characterBattle.Setup(isPlayerTeam);
        return characterBattle;
    }
    //function to set who's turn it is in combat
    private void SetActiveCharacterBattle(CharacterBattle characterBattle){
        if(activeCharacterBattle != null)
        {
            activeCharacterBattle.HideSelectionCircle();
        }
        activeCharacterBattle = characterBattle;
        activeCharacterBattle.ShowSelectionCircle();
    }
    //if it was your turn, this function changes it to not your turn and vice versa
    private void ChooseNextActiveCharacter(){
        if(TestBattleOver())
        {
            return;
        }
        if(activeCharacterBattle == playerCharacterBattle){
            SetActiveCharacterBattle(enemyCharacterBattle);
            state = State.Busy;
            enemyCharacterBattle.EnemyAttack(playerCharacterBattle,()=>{
                ChooseNextActiveCharacter();
            });
        }
        else{
            SetActiveCharacterBattle(playerCharacterBattle);
            state = State.WaitingForPlayer;
        }
    }
    //checks if win or lose conditions are met
    private bool TestBattleOver()
    {
        if(playerCharacterBattle.IsDead())
        {
            //Player dead, enemy wins
            battle_over_lose.SetActive(true);
            Debug.Log("player defeated");
            return true;
        }
        if(enemyCharacterBattle.IsDead())
        {
            //enemy dead, player wins
            battle_over_win.SetActive(true);
            Debug.Log("player wins");
            return true;
        }
        return false;
    }
}
