using UnityEngine;

public abstract class Inhabitant
{
    protected int currHp; 
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }

    public string getName()
    {
        return this.name;
    }

    public int attack()
    {
        return Random.Range(1, 10);
    }

    public void takeDamage(int damage)
    {
        this.currHp -= damage; 
    }

    public bool isAlive()
    {
        return this.currHp > 0; 
    }
}