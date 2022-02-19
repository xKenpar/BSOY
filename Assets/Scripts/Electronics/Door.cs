using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PoweredDevice
{
    BoxCollider2D m_collider;
    SpriteRenderer m_spriteRenderer;

    private void Start(){
        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (m_powered) {
            PowerOn();
        }
    }
    public override void PowerOn() {
        m_powered = true;
        m_collider.enabled = false;
        m_spriteRenderer.enabled = false;
    }

    public override void PowerOff() {
        m_powered = false;
        m_collider.enabled = true;
        m_spriteRenderer.enabled = true;
    }
}
