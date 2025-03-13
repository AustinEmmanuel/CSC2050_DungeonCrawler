using UnityEngine;
using System;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors; 
    private Dungeon theDungeon; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Austin");
        this.theDungeon = new Dungeon();
        
        this.setupRoom();
    }

    // disabling all the doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // try to move north 
            Debug.Log("Up Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("north");

            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // try to move south
            Debug.Log("Down Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // try to move west
            Debug.Log("Left Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // try to move east
            Debug.Log("Right Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            this.setupRoom();
        }
    }
}
