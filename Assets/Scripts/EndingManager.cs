using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public Rigidbody2D m_character;
    bool m_walking = false;

    IEnumerator end(float delay) {

        yield return new WaitForSeconds(delay);

        SceneController.Instance.NextLevel();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_walking) m_character.velocity = new Vector2(2f, 0f);
    }

    public void StartWalking() {
        m_character.GetComponent<Animator>().SetTrigger("Walk");
        m_walking = true;
        StartCoroutine(end(10f));
    }
}
