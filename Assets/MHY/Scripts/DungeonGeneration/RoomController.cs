using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo 
{
    public string name;

    public int X;

    public int Y;
}
public class RoomController : MonoBehaviour
{
    public static RoomController instance;

    string currentWorldName = "Forgot";

    RoomInfo currentLoadRoomData;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo> ();

    public List<Room> loadedRooms = new List<Room> ();

    bool isLoadingRoom = false;

    void Awake()
    {
        instance = this;
    }
    //방이 존재하는지 확인 하는 것
    public bool DoesRoomExist(int x, int y) 
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y ) != null;
    }
}
