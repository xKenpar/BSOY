using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : PoweredDevice
{
    [SerializeField] BoxCollider2D m_triggerCollider;
    [SerializeField] bool m_direction = true;
    [SerializeField] float m_power;
    List<Rigidbody2D> m_bodies = new List<Rigidbody2D>();
    void Update() {
        if (!m_powered) return;

        foreach (Rigidbody2D b in m_bodies) {
            b.velocity += new Vector2((m_direction ? 1: -1) * m_power * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.transform.CompareTag("Interactable")) {
            Debug.Log(collision.transform.name);
            m_bodies.Add(collision.GetComponent<Rigidbody2D>());
        }
           
    }

    void OnTriggerExit2D(Collider2D collision) {
        m_bodies.Remove(collision.GetComponent<Rigidbody2D>());
    }

    public override void PowerOn() {
        m_powered = true;
    }

    public override void PowerOff() {
        m_powered = false;
    }

}
