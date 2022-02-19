using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    Rigidbody2D m_rigidbody;
    public static Vector2 MousePosition;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        m_rigidbody = GetComponent<Rigidbody2D>();
        if(spawnPoint)
            transform.position = spawnPoint.position;
    }

    void Update() {
        m_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5));
        MousePosition = transform.position;
    }
}
