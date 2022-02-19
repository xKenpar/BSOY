using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum Direction {
    LEFT,
    RIGHT
}

public class RoomChanger : MonoBehaviour
{
    int m_currentRoom = 0;

    public void ChangeRoom(Direction direction) {
        switch (direction) {
            case Direction.LEFT:
                Left();
                break;
            
            case Direction.RIGHT:
                Right();
                break;
        }
    }

    void Left() {
        if (GameObject.Find("VirtualCamera" + (m_currentRoom - 1).ToString())){
            m_currentRoom--;
            GameObject.Find("VirtualCamera" + m_currentRoom.ToString()).GetComponent<CinemachineVirtualCamera>().enabled= true;
            GameObject.Find("VirtualCamera" + (m_currentRoom+1).ToString()).GetComponent<CinemachineVirtualCamera>().enabled= false;
        }
    }

    void Right() {
        if (GameObject.Find("VirtualCamera" + (m_currentRoom + 1).ToString())){
            m_currentRoom++;
            GameObject.Find("VirtualCamera" + m_currentRoom.ToString()).GetComponent<CinemachineVirtualCamera>().enabled= true;
            GameObject.Find("VirtualCamera" + (m_currentRoom-1).ToString()).GetComponent<CinemachineVirtualCamera>().enabled= false;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            ChangeRoom(Direction.LEFT);
        }
        
        else if (Input.GetKeyDown(KeyCode.R)) {
            ChangeRoom(Direction.RIGHT);
        }
    }
}
