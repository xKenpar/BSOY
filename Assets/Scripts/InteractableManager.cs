using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractableManager : MonoBehaviour
{
    public LayerMask m_DragLayers;
    public LayerMask m_CharacterLayers;

    [SerializeField] float m_damping = 1.0f;
    [SerializeField] float m_frequency = 5.0f;

    [SerializeField] Sprite m_idle;
    [SerializeField] Sprite m_clicked;
    private TargetJoint2D m_targetJoint;

    void Start() {
        EndingDoor.EndingOpened = false;
    }
    void Update () {
        Vector2 worldPos = MouseController.MousePosition;
        if(MouseController.m_spriteRenderer == null)
            return;

        if (Input.GetMouseButtonDown (0)) {
            Collider2D collider = Physics2D.OverlapPoint (worldPos, m_DragLayers);
            if (!collider) {
                if (EndingDoor.EndingOpened || LevelSelector.EndingOpened) {
                    collider = Physics2D.OverlapPoint(worldPos, m_CharacterLayers);

                    if (!collider) return;
                }
                else
                    return;
            }
                

            Rigidbody2D body = collider.attachedRigidbody;
            if (!body)
                return;

            MouseController.m_spriteRenderer.sprite = m_clicked;
            m_targetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
            m_targetJoint.dampingRatio = m_damping;
            m_targetJoint.frequency = m_frequency;

            m_targetJoint.anchor = m_targetJoint.transform.InverseTransformPoint (worldPos);
        } else if (Input.GetMouseButtonUp (0)) {
            MouseController.m_spriteRenderer.sprite = m_idle;
            Destroy (m_targetJoint);
            m_targetJoint = null;
            return;
        }

        if (m_targetJoint) {
            m_targetJoint.target = worldPos;
        }
    }
}