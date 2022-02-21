using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : PoweredDevice
{
    public static bool EndingOpened = false;
    [SerializeField] Transform PlatesParent;
    [SerializeField] Transform DoorsParent;
    [SerializeField] float m_delay;

    GameObject m_character;

    IEnumerator TriggerEnding(float delay) {
        //efektler falan iste
        string index = "1";
        foreach (Transform t in PlatesParent) {
            if (t.GetComponent<PowerSource>().m_powered) index = t.name;
        }

        yield return new WaitForSeconds(delay);
        EndingOpened = false;
        SceneController.Instance.LoadLevel("Level" + index);
    }
    void Start() {
        m_character = GameObject.FindGameObjectWithTag("Character");
        SetupDoors();
        if (m_powered) PowerOn();
    }

    public override void PowerOn() {
        m_powered = true;
        EndingOpened = true;
    }

    public override void PowerOff() {
        m_powered = false;
        EndingOpened = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Character")) return;

        StartCoroutine(TriggerEnding(m_delay));
    }

    void SetupDoors() {
        int currentLevel = SceneController.Instance.Load();

        foreach (Transform t in DoorsParent) {
            int index = Int32.Parse(t.name);

            if (currentLevel < index) break;
            t.gameObject.GetComponent<Door>().PowerOn();
        }
    }
}
