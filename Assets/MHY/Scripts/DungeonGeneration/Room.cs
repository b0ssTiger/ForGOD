using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;

    public int Height;

    public int X;

    public int Y;

    void Start()//시작 룸이 올바른 장면에서 시작하는지 확인 하는 것
    {
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene! ");
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }
    public Vector3 GetRoomCentre()
    { 
        return new Vector3( X * Width, Y * Height, 0 );    
    }
}
