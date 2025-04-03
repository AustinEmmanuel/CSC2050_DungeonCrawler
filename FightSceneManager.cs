using System;
using UnityEngine;
using TMPro;

public class fightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    public TMP_Text turnText;

    private float timeSinceLastTimeDeltaTime = 0.0f;

    private Fight theFight;

    private Vector3 playerStartPos;
    private Vector3 monsterStartPos;
    private Vector3 attackMove = new Vector3(1, 0, 0);

    private bool isPlayerTurn = true;
    private bool playerChoiceMade = false;

    // Add the missing variable
    private bool spaceBarPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.turnText.enabled = false;
        this.playerStartPos = this.player.transform.position;
        this.monsterStartPos = this.monster.transform.position;

        print("Player Max HP: " + Core.thePlayer.getMaxHp());
        print("Monster Max HP: " + Core.theMonster.getMaxHp());

        this.theFight = new Fight(Core.theMonster);
        print("Player AC: " + Core.thePlayer.getAC());
        print("Monster AC: " + Core.theMonster.getAC());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.spaceBarPressed = true;
        }

        this.timeSinceLastTimeDeltaTime += Time.deltaTime;

        // Move the combatants
        if (this.timeSinceLastTimeDeltaTime >= 0.5f)
        {
            // Happens every 1 second
            if (!this.theFight.isFightOver())
            {
                if (this.theFight.isPlayerTurn())
                {
                    this.turnText.enabled = true;

                    if (this.spaceBarPressed)
                    {
                        this.theFight.takeASwing(this.player, this.monster);
                        this.spaceBarPressed = false;
                        this.turnText.enabled = false;
                    }
                }

                if (!this.theFight.isPlayerTurn())
                {
                    // The monster takes a swing without any interaction
                    this.theFight.takeASwing(this.player, this.monster);
                }
            }
            else
            {
                Debug.Log("Fight is over");
            }
            this.timeSinceLastTimeDeltaTime = 0.0f;
        }
    }
}