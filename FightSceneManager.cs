using System;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    //private float timeSinceLastTimeDeltaTime = 0.0f;

    private Fight theFight;

    private Vector3 playerStartPos;
    private Vector3 monsterStartPos;


    private bool hasPlayerDoneSomething = false;
    private bool isPlayerTurn = false;
    private bool turnPrint = false;

    //private Vector3 attackMove = new Vector3(1f, 0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerStartPos = this.player.transform.position;
        this.monsterStartPos = this.monster.transform.position;


        print("Player Max HP: " + Core.thePlayer.getMaxHp());
        print("Monster Max HP: " + Core.theMonster.getMaxHp());

        this.theFight = new Fight (Core.theMonster);

        this.isPlayerTurn = Core.thePlayer == theFight.getAttacker();
        //theFight.startFight(player, monster)
    }

    // Update is called once per frame.
    void Update()
    {
        if (theFight.isFightover())
        {
            return;
        }
        if (isPlayerTurn && !hasPlayerDoneSomething)
        {
            if (!turnPrint)
            {
                Debug.Log("Player's turn. ");
                Debug.Log("Player HP: " + Core.thePlayer.getCurrHp());
                Debug.Log("Monster HP: " + Core.theMonster.getCurrHp());
                Debug.Log("Press UpArrow for normal attack, DownArrow for heavy, RightArrow for heal.");
                turnPrint = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                theFight.normalSwing(player, monster);
                hasPlayerDoneSomething = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                theFight.heavySwing(player, monster);
                hasPlayerDoneSomething = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                theFight.heal(player);
                hasPlayerDoneSomething = true;
            }
            if(hasPlayerDoneSomething)
            {
                isPlayerTurn = false;
                turnPrint = false;
            }
        }
        else
        {
            Debug.Log("Monster's turn.");
            theFight.normalSwing(player, monster);
            isPlayerTurn = true;
            hasPlayerDoneSomething = false;
        }
    }
}