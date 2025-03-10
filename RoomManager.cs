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
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // try to move south
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // try to move west
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // try to move east
        }
    }
}
