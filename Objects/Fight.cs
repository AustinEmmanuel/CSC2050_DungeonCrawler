using UnityEngine;
using System;
public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public Fight(Inhabitant attacker, Inhabitant defender)
    {
        this.attacker = attacker;
        this.defender = defender;

        int roll = UnityEngine.Random.Range(0, 20) + 1;
        if (roll <= 10)
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
        bool isAttackerTurn = UnityEngine.Random.Range(0, 20) + 1 <= 10; 
        
        while (attacker.isAlive() && defender.isAlive()) 
        {
            if (isAttackerTurn)
            {
                Attack(attacker, defender);
                isAttackerTurn = false; 
            }
            else
            {
                Attack(defender, attacker);
                isAttackerTurn = true; 
            }
        }

        // Determine who won
        if (attacker.isAlive())
        {
            Debug.Log(attacker.getName() + " wins!");
        }
        else
        {
            Debug.Log(defender.getName() + " wins!");
        }
    }

    private void Attack(Inhabitant attacker, Inhabitant defender)
    {
        // Generate the attack damage and apply it to the defender
        int damage = attacker.attack(); 
        defender.takeDamage(damage); 

        Debug.Log(attacker.getName() + " attacks " + defender.getName() + " for " + damage + " damage.");
    }
}