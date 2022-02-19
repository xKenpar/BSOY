using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Rigidbody2D m_rigidbody;
    
    public static Vector2 MousePosition;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        m_rigidbody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        MousePosition = transform.position;
    }
}
