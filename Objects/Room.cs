using UnityEngine;

public class Room
{
    private Player thePlayer; 
    private GameObject[] theDoors;
    private Exit[] availableExits = new Exit[4];
    private int currNumberOfExits = 0;
    private string name;

    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);
    }

    public void addExit(string direction, Room destination)
    {
        if(this.currNumberOfExits <= 3)
        {
            Exit e = new Exit(direction, destination); 
            this.availableExits[this.currNumberOfExits] = e; 
            this.currNumberOfExits++; 
        }
        else
        {
            Debug.Log("There are too many exits!"); // testing
        }
        
    }


}
