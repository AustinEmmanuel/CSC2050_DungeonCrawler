using System;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private Monster theMonster;

    private float timeSinceLastTimeDeltaTime = 0.0f;

    private Fight theFight;

    private Vector3 playerStartPos;
    private Vector3 monsterStartPos;
    private Vector3 attackMove = new Vector3(1, 0, 0);

    private bool isPlayerTurn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerStartPos = this.player.transform.position;
        this.monsterStartPos = this.monster.transform.position;

        this.theMonster = new Monster("Goblin");
        this.theFight = new Fight(this.theMonster);
        print("Player AC: " + Core.thePlayer.getAC());
        print("Monster AC: " + this.theMonster.getAC());

        //f.startFight(player, monster); //we need this to be experienced over time, so we need it to be represented in Update

    }

    // Update is called once per frame
    void Update()
    {
        this.timeSinceLastTimeDeltaTime += Time.deltaTime;

        //move the combatants
        if(this.timeSinceLastTimeDeltaTime >= 0.25f)
        {
            if(!this.isPlayerTurn)
            {
                this.player.transform.position = this.playerStartPos;
                this.monster.transform.position += this.attackMove;
                this.isPlayerTurn = true;

            }
            else
            {
                this.monster.transform.position = this.monsterStartPos;
                this.player.transform.position -= this.attackMove;
                this.isPlayerTurn = false;
            }
        }

        if(this.timeSinceLastTimeDeltaTime >= 0.5f)
        {
            //happens every 1 seconds
            if(!this.theFight.isFightOver())
            {
                //the attacker should visibly move
                this.player.transform.position -= this.attackMove;
                this.theFight.takeASwing(this.player, this.monster);
            }
            else
            {
                Debug.Log("Fight is over");
            }
            this.timeSinceLastTimeDeltaTime = 0.0f;
        }
    }
}