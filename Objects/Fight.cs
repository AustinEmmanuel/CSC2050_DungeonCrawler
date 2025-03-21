using UnityEngine;
using System;
public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    private Monster theMonster;

    public Fight(Monster m)
    {
        this.theMonster = m;

        // initially determine who goes first 
        int roll = UnityEngine.Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }
    }

    public void startFight(GameObject playerGO, GameObject monsterGO)
    {
        while(true)
        {
            int attackRoll = UnityEngine.Random.Range(0, 20) + 1;
            if(attackRoll >= this.defender.getAc())
            {
                // attacker hits the defender
                int damage = UnityEngine.Random.Range(1, 6); // 1 to 5 damage
                this.defender.takeDamage(damage);

                if(this.defender.isDead())
                {
                    Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
                    if(this.defender is Player)
                    {
                        // player is dead, end game
                        playerGO.SetActive(false); // hide the player 
                    }
                    else
                    {
                        // monster died
                        Debug.Log("Monster dead");
                        GameObject.Destroy(monsterGO); // remove the monster from the scene
                        
                    }
                    break; // exit the fight loop
                }
            }
            else
            {
                Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
            }
            Inhabitant temp = this.attacker;
            this.attacker = this.defender;
            this.defender = temp;
        }
    }
}