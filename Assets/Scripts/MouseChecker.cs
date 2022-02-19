using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChecker : MonoBehaviour
{
    Camera m_camera;
    GameObject m_lastHittedObject;
    GameObject m_newHittedObject;

    void Start() {
        m_camera = Camera.main;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(m_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Interactable"));
            
            if (hit) {
                GameObject hittedObject = hit.collider.gameObject;

                if (hittedObject.CompareTag("Interactable")) {
                    m_newHittedObject = hittedObject;

                    Transform intractable = hittedObject.transform.Find("Interactable");
                    if (intractable){
                        intractable.gameObject.SetActive(true);
                    }

                    CheckHittedObjects();
                }
            }
        }
    }

    void CheckHittedObjects() {
        if (m_lastHittedObject) {
            if (!ReferenceEquals(m_lastHittedObject, m_newHittedObject)) {
                m_lastHittedObject.transform.Find("Interactable").gameObject.SetActive(false);
            }
            m_lastHittedObject = m_newHittedObject;
        } else {
            m_lastHittedObject = m_newHittedObject;
        }
    }
}
