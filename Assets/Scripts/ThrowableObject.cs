using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    Rigidbody2D m_rigidbody;
    Camera m_camera;
    
    void Start() {
        m_rigidbody = transform.parent.GetComponent<Rigidbody2D>();
        m_camera = Camera.main;
    }

    void Update() {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButton(0))
            m_rigidbody.velocity = -(transform.position - m_camera.ScreenToWorldPoint(Input.mousePosition)) * 10f;
    }
}
