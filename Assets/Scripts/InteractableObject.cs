using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    Rigidbody2D m_parentRigidbody;
    Camera m_camera;

    [SerializeField] float Power;
    
    void Start() {
        m_parentRigidbody = transform.parent.GetComponent<Rigidbody2D>();
        m_camera = Camera.main;
    }

    void Update() {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButton(0))
            m_parentRigidbody.velocity = -(transform.position - m_camera.ScreenToWorldPoint(Input.mousePosition)) * Power;
    }
}
