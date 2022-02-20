using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PoweredDevice
{
    [SerializeField] BoxCollider2D m_openedCollider;
    [SerializeField] BoxCollider2D[] m_closedCollider;
    [SerializeField] Animator m_animator;

    private void Start(){
        m_animator = GetComponent<Animator>();
        if (m_powered) {
            PowerOn();
        }
    }
    public override void PowerOn() {
        m_powered = true;
        m_animator.SetTrigger("Close");
        m_openedCollider.enabled = false;
        for (int i = 0; i < m_closedCollider.Length; i++) {
            m_closedCollider[i].enabled = true;
        }
    }

    public override void PowerOff() {
        m_powered = false;
        m_animator.SetTrigger("Open");
        m_openedCollider.enabled = true;
        for (int i = 0; i < m_closedCollider.Length; i++) {
            m_closedCollider[i].enabled = false;
        }
    }
}
