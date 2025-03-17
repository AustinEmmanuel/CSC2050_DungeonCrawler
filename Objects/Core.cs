using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public static Player thePlayer;
    public static Vector3 mmStartPos = new Vector3(14.32f, 0, 0);

    //what kind of collection lets us store an arbitrary number of room names?
    private static List<string> roomNames = new List<string>();
    private static void addRoomName(string name)
    {
        roomNames.Add(name);
    }

    public static bool hasBeenToRoom(string name)
    {
        bool answer = Core.roomNames.Contains(name);
        if(!answer)
        {
            Core.addRoomName(name);
        }
        return answer;
    }
}