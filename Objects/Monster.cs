using UnityEngine;

public class Monster : Inhabitant
{
    public Monster(string name) : base(name)
    {
       
    }

    public int getCurrHp()
    {
        return this.currHp; 
    }

    // public string getName()
    // {
    //     return this.name; 
    // }
}
