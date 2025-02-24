using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors; 
    private Dungeon theDungeon; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Austin");
        this.theDungeon = new Dungeon();

        this.theDoors[0].SetActive(Core.northDoor);
        this.theDoors[1].SetActive(Core.southDoor);
        this.theDoors[2].SetActive(Core.eastDoor);
        this.theDoors[3].SetActive(Core.westDoor);
        //MeshRenderer mr = this.theDoors[0].GetComponent<MeshRenderer>();
        //mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
