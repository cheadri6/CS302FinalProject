using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CharacterBattle : MonoBehaviour
{
    private State state; // is the character idling, attacking, or waiting
    private Vector3 slideTargetPosition; //where is the target located
    private Action onSlideComplete; //slide has finished
    private GameObject selectionCircleGameObject; //highlights active player with green circle
    private HealthSystem healthSystem, magicSystem; // system that handles health and magic consumption
    private World_Bar healthBar, magicBar; //visual bars

    private enum State
    {
        Idle,
        Sliding,
        Busy,

    }
    private void Awake()
    {
        selectionCircleGameObject = transform.Find("selection_circle").gameObject;
        HideSelectionCircle();
    }

    private void Start()
    {

    }
    //sets up fighter depending on if it is the player or enemy with appropriate health and magic
    public void Setup(bool isPlayerTeam)
    {
        if (isPlayerTeam)
        {
            //Spawn Player
            healthBar = new World_Bar(transform, new Vector3(0, (float)0.165), new Vector3((float)0.6, (float)0.1), Color.grey, Color.red, 1f, 100, new World_Bar.Outline { color = Color.black, size = .125f });
            magicBar = new World_Bar(transform, new Vector3(0, (float)0.125), new Vector3((float)0.6, (float)0.1), Color.grey, Color.blue, 1f, 100, new World_Bar.Outline { color = Color.black, size = .125f });
            magicSystem = new HealthSystem(100);
        }
        else
        {
            //Spawn Enemy
            healthBar = new World_Bar(transform, new Vector3(0, (float)1.25), new Vector3((float)0.6, (float)0.1), Color.grey, Color.red, 1f, 100, new World_Bar.Outline { color = Color.black, size = .125f });
        }
        healthSystem = new HealthSystem(100);

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    //check for health only when it is changed
    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        healthBar.SetSize(healthSystem.GetHealthPercent());
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Busy:
                break;
            case State.Sliding:
                float slideSpeed = 5f;
                transform.position += (slideTargetPosition - GetPosition()) * slideSpeed * Time.deltaTime;

                float reachedDistance = 1f;
                if (Vector3.Distance(GetPosition(), slideTargetPosition) < reachedDistance)
                {
                    transform.position = slideTargetPosition;
                    onSlideComplete();
                }
                break;
        }
    }
    //returns position of item
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    //reduce health system
    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }
    //reduce magic system
    public void UseSpell(int spellCost)
    {
        magicSystem.UseSpell(spellCost);
        magicBar.SetSize(magicSystem.GetHealthPercent());
    }
    //checks if fighter's health drops to 0 or below
    public bool IsDead()
    {
        return healthSystem.IsDead();
    }
    //sword attack
    public void Attack(CharacterBattle targetCharacterBattle, Action onAttackComplete)
    {
        Vector3 slideTargetPosition = new Vector3(4, -1, 0);
        Vector3 startingPosition = GetPosition();
        SlideToPosition(slideTargetPosition, () =>
        {
            state = State.Busy;
            targetCharacterBattle.Damage(20);
            SlideToPosition(startingPosition, () =>
            {
                state = State.Idle;
                onAttackComplete();
            });

        });
    }
    //magic attack
    public void Spell(CharacterBattle targetCharacterBattle,CharacterBattle selfCharacterBattle, Action onAttackComplete)
    {
        
        targetCharacterBattle.Damage(50);
        selfCharacterBattle.UseSpell(50);
        onAttackComplete();
    }
    //enemy's attack
    public void EnemyAttack(CharacterBattle targetCharacterBattle, Action onAttackComplete)
    {
        Vector3 slideTargetPosition = new Vector3(-4, -1, 0);
        Vector3 startingPosition = GetPosition();
        SlideToPosition(slideTargetPosition, () =>
        {
            state = State.Busy;
            targetCharacterBattle.Damage(40);
            SlideToPosition(startingPosition, () =>
            {
                state = State.Idle;
                onAttackComplete();
            });

        });
    }
    //slides object to a target position
    private void SlideToPosition(Vector3 slideTargetPosition, Action onSlideComplete)
    {
        this.slideTargetPosition = slideTargetPosition;
        this.onSlideComplete = onSlideComplete;
        state = State.Sliding;
    }
    //turns off selection circle game object
    public void HideSelectionCircle()
    {
        selectionCircleGameObject.SetActive(false);
    }
    //turns on selection circle game object
    public void ShowSelectionCircle()
    {
        selectionCircleGameObject.SetActive(true);
    }
}
