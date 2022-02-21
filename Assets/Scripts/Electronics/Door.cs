using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PoweredDevice
{
    [SerializeField] BoxCollider2D m_openedCollider;
    [SerializeField] BoxCollider2D[] m_closedCollider;
    [SerializeField] Animator m_animator;
    AudioSource m_doorSfx;

    private void Start(){
        m_animator = GetComponent<Animator>();
        if (m_powered) {
            PowerOn();
        }

        m_doorSfx = GetComponent<AudioSource>();
    }
    public override void PowerOn() {
        m_powered = true;
        m_animator.SetBool("Close",true);
        m_animator.SetBool("Open",false);
        m_openedCollider.enabled = false;
        for (int i = 0; i < m_closedCollider.Length; i++) {
            m_closedCollider[i].enabled = true;
        }

        AudioManager.Instance.triggerAudio(0);
    }

    public override void PowerOff() {
        m_powered = false;
        m_animator.SetBool("Close",false);
        m_animator.SetBool("Open",true);
        m_openedCollider.enabled = true;
        for (int i = 0; i < m_closedCollider.Length; i++) {
            m_closedCollider[i].enabled = false;
        }

        AudioManager.Instance.triggerAudio(0);
    }
}
