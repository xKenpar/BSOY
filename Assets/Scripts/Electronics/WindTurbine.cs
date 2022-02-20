using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : PoweredDevice
{
    [SerializeField] BoxCollider2D m_triggerCollider;
    [SerializeField] bool m_direction = true;
    [SerializeField] float m_power;

    ParticleSystem m_particle;
    List<Rigidbody2D> m_bodies = new List<Rigidbody2D>();

    void Start() {
        m_particle = GetComponentInChildren<ParticleSystem>();
    }
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
        m_particle.Play();
    }

    public override void PowerOff() {
        m_powered = false;
        m_particle.Stop();
    }

}
