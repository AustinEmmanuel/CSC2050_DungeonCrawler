using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    private Monster theMonster;

    private bool fightOver = false;

    public Fight(Monster m)
    {
        this.theMonster = m;

        // Initially determine who goes first
        int roll = Random.Range(0, 20) + 1;
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

    public bool isFightOver()
    {
        return this.fightOver;
    }

    // Add this method to return the current attacker
    public Inhabitant getAttacker()
    {
        return this.attacker;
    }

    public void takeASwing(GameObject playerGameObject, GameObject monsterGameObject, string action = "normal")
    {
        if (this.attacker is Player)
        {
            // Player's turn
            if (action == "power")
            {
                // Power attack: 50% more damage, -25% attack roll
                int attackRoll = Mathf.FloorToInt((Random.Range(0, 20) + 1) * 0.75f);
                Debug.Log("Player Power Attack Roll: " + attackRoll);
                if (attackRoll >= this.defender.getAC())
                {
                    int damage = Mathf.FloorToInt(Random.Range(1, 6) * 1.5f); // 50% more damage
                    this.defender.takeDamage(damage);
                    Debug.Log("Player hits with a power attack for " + damage + " damage!");
                }
                else
                {
                    Debug.Log("Player's power attack missed!");
                }
            }
            else if (action == "potion")
            {
                // Drink a potion: Heal 25% of max health
                Player player = (Player)this.attacker;
                int healAmount = Mathf.FloorToInt(player.getMaxHealth() * 0.25f);
                player.heal(healAmount);
                Debug.Log("Player drinks a potion and heals for " + healAmount + " HP!");
            }
            else
            {
                // Normal attack
                int attackRoll = Random.Range(0, 20) + 1;
                Debug.Log("Player Normal Attack Roll: " + attackRoll);
                if (attackRoll >= this.defender.getAC())
                {
                    int damage = Random.Range(1, 6);
                    this.defender.takeDamage(damage);
                    Debug.Log("Player hits for " + damage + " damage!");
                }
                else
                {
                    Debug.Log("Player's normal attack missed!");
                }
            }
        }
        else
        {
            // Monster's turn: Always normal attack
            int attackRoll = Random.Range(0, 20) + 1;
            Debug.Log("Monster Attack Roll: " + attackRoll);
            if (attackRoll >= this.defender.getAC())
            {
                int damage = Random.Range(1, 6);
                this.defender.takeDamage(damage);
                Debug.Log("Monster hits for " + damage + " damage!");
            }
            else
            {
                Debug.Log("Monster's attack missed!");
            }
        }

        // Check if the defender is dead
        if (this.defender.isDead())
        {
            this.fightOver = true;
            Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
            return;
        }

        // Swap attacker and defender for the next turn
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }
}