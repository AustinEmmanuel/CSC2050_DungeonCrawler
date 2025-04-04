using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
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

        //Initially determine who goes first
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

    public bool isFightover()
    {
        return this.fightOver;
    }

    public Inhabitant getAttacker()
    {
        return this.attacker;
    }

    public void normalSwing(GameObject playerGameObject, GameObject monsterGO)
    {
        int attackRoll = Random.Range(1, 20) + 1;
        if (attackRoll >= this.defender.getAC())
        {
            int damage = Random.Range(1, 6);
            this.defender.takeDamage(damage);
            Debug.Log(this.attacker.getName() + " hits " + this.defender.getName() + " for " + damage + " damage!");
        }
        else
        {
            Debug.Log(this.attacker.getName() + " misses " + this.defender.getName() + "!");
        }

        if (this.defender.isDead())
        {
            this.fightOver = true;
            Debug.Log(this.defender.getName() + " has been defeated!");
            if (this.defender is Player)
            {
                Debug.Log("Player died!");
                playerGameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Monster died!");
                GameObject.Destroy(monsterGO);
            }
        }
        // Swap roles
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }

    public void heavySwing(GameObject playerGameObject, GameObject monsterGO)
    {
        int attackRoll = Random.Range(1, 20) + 1;
        if (attackRoll >= this.defender.getAC() + 7)
        {
            int damage = attackRoll + 7;
            this.defender.takeDamage(damage);
            Debug.Log(this.attacker.getName() + " hits " + this.defender.getName() + " for " + damage + " damage!");
        }
        else
        {
            Debug.Log(this.attacker.getName() + " misses " + this.defender.getName() + "!");
        }
        if (this.defender.isDead())
        {
            this.fightOver = true;
            Debug.Log(this.defender.getName() + " has been defeated!");
            if (this.defender is Player)
            {
                Debug.Log("Player died!");
                playerGameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Monster died!");
                GameObject.Destroy(monsterGO);
            }
        }
        // Swap roles
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }
    
    public void heal(GameObject playerGameObject)
    {
        int healAmount = Random.Range(5, 15);
        this.attacker.setCurrHp(this.attacker.getCurrHp() + healAmount);
        if (this.attacker.getCurrHp() > this.attacker.getMaxHp())
        {
            this.attacker.setCurrHp(this.attacker.getMaxHp());
        }
        Debug.Log(this.attacker.getName() + " heals for " + healAmount + " health!");
        // Swap roles
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }
}