using UnityEngine;

public class Fight
{
    private Inhabitant attacker; 
    private Inhabitant defender;

    public Fight()
    {
        int roll = Random.Range(0, 20) + 1; 
        if(roll <= 10)
        {
            Debug.Log("Monster goes first");
        }
        else
        {
            Debug.Log("Player goes first");
        } 
    }

    public void startFight()
    {
        // should have the attacker and defender fight each other until one of them is dead.
        // the attacker and the defender should alternate between attacking each other.
    
    
    }
}
