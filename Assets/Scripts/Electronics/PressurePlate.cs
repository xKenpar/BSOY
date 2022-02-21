using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerSource))]
public class PressurePlate : MonoBehaviour 
{
    [SerializeField] Sprite m_unPressed;
    [SerializeField] Sprite m_pressed;

    SpriteRenderer m_renderer;
    PowerSource m_powerSource;
    int m_triggerCount = 0;
    
    void Start() {
        m_powerSource = GetComponent<PowerSource>();
        m_renderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if ((!collision.CompareTag("Interactable") && !collision.CompareTag("Fist")) || collision.isTrigger) return;

        if (m_triggerCount == 0) {
            m_powerSource.PowerOn();
            m_renderer.sprite = m_pressed;
            AudioManager.Instance.triggerAudio(1);
        }
        m_triggerCount++;
    }

    void OnTriggerExit2D(Collider2D collision) {

        if ((!collision.CompareTag("Interactable") && !collision.CompareTag("Fist")) || collision.isTrigger) return;

        if (m_triggerCount == 1) {
            m_powerSource.PowerOff();
            m_renderer.sprite = m_unPressed;
            AudioManager.Instance.triggerAudio(1);
        }
        m_triggerCount--;
    }

    public void AddMouseTrigger(){
        if (m_triggerCount == 0) {
            m_powerSource.PowerOn();
            m_renderer.sprite = m_pressed;
            AudioManager.Instance.triggerAudio(1);
        }
        m_triggerCount++;
    }

    public void RemoveMouseTrigger(){
        if (m_triggerCount == 1) {
            m_powerSource.PowerOff();
            m_renderer.sprite = m_unPressed;
            AudioManager.Instance.triggerAudio(1);
        }
        m_triggerCount--;
    }
}
