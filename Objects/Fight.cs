using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private float attackInterval = 0.2f; // Time between attacks in seconds
    private float timeSinceLastAttack = 0.0f;
    private bool fightOver = false;

    public Fight(Inhabitant player, Inhabitant monster)
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = monster;
            this.defender = player;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = player;
            this.defender = monster;
        }
    }

    public void UpdateFight(float deltaTime, GameObject playerGO, GameObject monsterGO)
    {
        if (fightOver)
        {
            return; // Exit if the fight is over
        }

        timeSinceLastAttack += deltaTime;

        if (timeSinceLastAttack >= attackInterval)
        {
            timeSinceLastAttack = 0.0f; // Reset the timer

            int attackRoll = Random.Range(0, 20) + 1;
            if (attackRoll >= this.defender.getAc())
            {
                // Attacker hits the defender
                int damage = Random.Range(1, 6); // 1 to 5 damage
                this.defender.takeDamage(damage);

                if (this.defender.isDead())
                {
                    Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
                    fightOver = true; // Set the flag to indicate the fight is over
                    if (this.defender is Player)
                    {
                        // Player is dead, end game
                        playerGO.SetActive(false); // Hide the player
                    }
                    else
                    {
                        // Monster died
                        Debug.Log("Monster dead");
                        GameObject.Destroy(monsterGO); // Remove the monster from the scene
                    }
                    return; // Exit the fight loop
                }
            }
            else
            {
                Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
            }

            // Swap attacker and defender for the next round
            Inhabitant temp = this.attacker;
            this.attacker = this.defender;
            this.defender = temp;
        }
    }
}