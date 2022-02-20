using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    GameObject VCam;
    void Start() {
        VCam = transform.GetChild(0).gameObject;
        VCam.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Mouse"))
            VCam.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Mouse"))
            VCam.SetActive(false);
    }
}
