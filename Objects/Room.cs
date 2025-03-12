using UnityEngine;
using System;

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

    public string getName()
    {
        return this.name;
    }

    public void tryToTakeExit(string direction)
    {
        if(this.hasExit(direction))
        {
            for(int i = 0; i < this.currNumberOfExits; i++)
            {
                if(String.Equals(this.availableExits[i].getDirection(), direction))
                {
                  // get the destination room in that direction
                  Room destinationRoom = this.availableExits[i].getDestination();

                  // remove the player from the current room
                  this.thePlayer = null; 

                  // place them in the destination room in that direction
                  destinationRoom.setPlayer(Core.thePlayer); 
                  
                  // update the room the player is currently in so the room exits visually update
                  Core.thePlayer.setCurrentRoom(destinationRoom);

                  // Logging
                  Debug.Log("The player has moved to the " + destinationRoom.getName()); 

                  return;
                }
            }
        }
        else
        {
            Debug.Log("There is no exit in that direction!"); // testing
        }
    }

    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.currNumberOfExits; i++)
        {
            if(String.Equals(this.availableExits[i].getDirection(), direction))
            {
                return true;
            }
        }
        return false;
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
