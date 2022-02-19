using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum Direction {
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public class RoomChanger : MonoBehaviour
{
    [SerializeField] CinemachineBrain m_cameraBrain;
    [SerializeField] RoomController m_currentRoom;
    float dampingTime;

    void Start() {
        
    }
    public void ChangeRoom(Direction direction) {
        switch (direction) {
            case Direction.LEFT:
                if (m_currentRoom.LeftRoom != null) ChangeRoom(m_currentRoom.LeftRoom); 
                break;
            case Direction.RIGHT:
                if (m_currentRoom.RightRoom != null) ChangeRoom(m_currentRoom.RightRoom);
                break;
            case Direction.UP:
                if (m_currentRoom.UpRoom != null) ChangeRoom(m_currentRoom.UpRoom);
                break;
            case Direction.DOWN:
                if (m_currentRoom.DownRoom != null) ChangeRoom(m_currentRoom.DownRoom);
                break;
        }
    }

    void ChangeRoom(RoomController room) {
        m_currentRoom.VirtualCam.SetActive(false);
        m_currentRoom = room;
        m_currentRoom.VirtualCam.SetActive(true);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            ChangeRoom(Direction.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            ChangeRoom(Direction.RIGHT);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangeRoom(Direction.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ChangeRoom(Direction.DOWN);
        }
    }
}
