using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableParticles : MonoBehaviour
{
    [SerializeField] GameObject HitParticle;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.relativeVelocity.magnitude > 5) {
            Instantiate(HitParticle, other.contacts[0].point, Quaternion.identity);
            AudioManager.Instance.triggerAudio(2);
        }
    }
}
