using UnityEngine;
using System;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors; 
    public GameObject mmRoomPrefab;
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
    private Vector3 minimapPosition = new Vector3(14.32f, 0, 0);

    // Orignial Logic
    /*
        GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
        Vector3 currPos = newMMRoom.transform.position;
        Vector3 newPos = currPos;
        newPos.x = currPos.x;
        newPos.y = currPos.y;
        newPos.z = currPos.z + 1.2f;
        newMMRoom.transform.position = newPos;
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("north");

            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 newPos = minimapPosition;
            newPos.z += 1.2f; // Move forward
            newMMRoom.transform.position = newPos;

            // Update tracked position
            minimapPosition = newPos; 
            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("south");

            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 newPos = minimapPosition;
            newPos.z -= 1.2f; // Move backward
            newMMRoom.transform.position = newPos;

            // Update tracked position
            minimapPosition = newPos;
            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("west");

            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 newPos = minimapPosition;
            newPos.x -= 1.2f; // Move left
            newMMRoom.transform.position = newPos;

            // Update tracked position
            minimapPosition = newPos;
            this.setupRoom();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow Pressed");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("east");

            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 newPos = minimapPosition;
            newPos.x += 1.2f; // Move right
            newMMRoom.transform.position = newPos;

            // Update tracked position
            minimapPosition = newPos;
            this.setupRoom();
        }
    }
}
