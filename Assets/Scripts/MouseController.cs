using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point pos);

    [SerializeField] Transform spawnPoint;

    Rigidbody2D m_rigidbody;

    public static Vector2 MousePosition;
    
    [SerializeField] float sensitivityX = 15F;
    [SerializeField] float sensitivityY = 15F;

    Camera m_mainCamera;

    Vector2 m_cursorSetPoint;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        m_rigidbody = GetComponent<Rigidbody2D>();
        if(spawnPoint)
            transform.position = spawnPoint.position;

        m_mainCamera = Camera.main;
        
        m_cursorSetPoint = new Vector2(Screen.width/2f,Screen.height/2f);
        SetCursorPos((int)m_cursorSetPoint.x,(int)m_cursorSetPoint.y);
    }

    void Update() {
        Point cursorPos = new Point();
        GetCursorPos(out cursorPos);
        if(new Vector2(cursorPos.X,cursorPos.Y) != m_cursorSetPoint){
            Debug.Log(new Vector2(cursorPos.X,cursorPos.Y) + " - - " + m_cursorSetPoint);
            Debug.Log(m_mainCamera.ScreenToWorldPoint(new Vector2(cursorPos.X,cursorPos.Y)-m_cursorSetPoint));
        }

        Debug.Log(Time.deltaTime);
        Vector3 mouseMovementVector = m_mainCamera.ScreenToWorldPoint(new Vector2(cursorPos.X,cursorPos.Y))-m_mainCamera.ScreenToWorldPoint(m_cursorSetPoint);
        mouseMovementVector *= new Vector2(1,-1);
        m_rigidbody.MovePosition(transform.position + mouseMovementVector);
        SetCursorPos((int)m_cursorSetPoint.x,(int)m_cursorSetPoint.y);

        MousePosition = transform.position;
    }
}
