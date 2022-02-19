using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDoor : PoweredDevice {
    BoxCollider2D m_collider;
    SpriteRenderer m_spriteRenderer;

    float m_remainingTime = 2f;
    void Start() {
        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (m_powered) {
            PowerOn();
        }
    }

    void Update() {
        if (m_powered) {
            m_remainingTime -= Time.deltaTime;
            if (m_remainingTime < 0) {
                SceneController.Instance.NextLevel();
            }
        }else {
            m_remainingTime = 2;
        }

    }
    public override void PowerOn() {
        m_powered = true;
        m_collider.enabled = false;
        m_spriteRenderer.enabled = false;
    }

    public override void PowerOff() {
        m_powered = false;
        m_spriteRenderer.enabled = true;
    }
}
