using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerSource))]
public class PressurePlate : MonoBehaviour 
{
    PowerSource m_powerSource;
    int m_triggerCount = 0;
    
    void Start() {
        m_powerSource = GetComponent<PowerSource>();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Interactable") || collision.isTrigger) return;

        if (m_triggerCount == 0) m_powerSource.PowerOn();
        m_triggerCount++;
    }

    void OnTriggerExit2D(Collider2D collision) {

        if (!collision.CompareTag("Interactable") || collision.isTrigger) return;

        if (m_triggerCount == 1) m_powerSource.PowerOff();
        m_triggerCount--;
    }
}
