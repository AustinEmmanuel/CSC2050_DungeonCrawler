using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    private Inhabitant player;
    private Inhabitant monster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = new Player("Austin");   
        monster = new Monster("Goblin");
        
        
        Fight fight = new Fight(player, monster);
        
       
        fight.startFight();
    }

    // Update is called once per frame
    void Update()
    {
        // You can put logic here to handle updates during the fight (if needed)
    }
}
