using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private Fight fight;
    private Monster theMonster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the player
        Core.thePlayer = new Player("Player");

        // Initialize the monster
        this.theMonster = new Monster("Goblin");

        // Create the fight
        fight = new Fight(Core.thePlayer, this.theMonster);
    }

    // Update is called once per frame
    void Update()
    {
        if (fight != null)
        {
            fight.UpdateFight(Time.deltaTime, player, monster);
        }
    }
}