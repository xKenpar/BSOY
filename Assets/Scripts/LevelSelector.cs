using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : PoweredDevice
{
    public static bool EndingOpened = false;
    [SerializeField] Transform platesParent;
    [SerializeField] float m_delay;

    GameObject m_character;

    IEnumerator TriggerEnding(float delay) {
        //efektler falan iste
        string index = "1";
        foreach (Transform t in platesParent) {
            if (t.GetComponent<PowerSource>().m_powered) index = t.name;
        }

        yield return new WaitForSeconds(delay);

        SceneController.Instance.LoadLevel("Level" + index);
    }
    void Start() {
        m_character = GameObject.FindGameObjectWithTag("Character");

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
}
