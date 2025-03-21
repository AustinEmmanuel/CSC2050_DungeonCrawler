using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private Monster theMonster;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Core.thePlayer = new Player("Player");
        this.theMonster = new Monster("Goblin");
        Fight fight = new Fight(this.theMonster);
        
        fight.startFight(player, monster); // we need this to be experienced over time, so we need to 
    }

    // Update is called once per frame
    void Update()
    {
        // You can put logic here to handle updates during the fight (if needed)
    }
}
