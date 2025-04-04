using UnityEngine;

public abstract class Inhabitant
{
    //core components of inhabitant
    protected int currHp;
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(1, 10);
    }

    public int getMaxHp()
    {
        return this.maxHp;
    }
    public int getCurrHp()
    {
        return this.currHp;
    }
    public int setCurrHp(int hp)
    {
        this.currHp = hp;
        return this.currHp;
    }
    public int getAC()
    {
        return this.ac;
    }
    public string getName()
    {
        return this.name;
    }

    public void display()
    {
        Debug.Log(getName());
        Debug.Log("HP = " + getCurrHp());
        Debug.Log("AC = " + getAC());
    }

    public void takeDamage(int damage)
    {
        this.currHp = this.currHp - damage;
        if (this.currHp < 0)
        {
            this.currHp = 0;
        }
    }

    public bool isDead()
    {
        if(currHp == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}