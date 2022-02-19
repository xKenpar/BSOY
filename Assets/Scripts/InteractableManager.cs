using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public LayerMask m_DragLayers;

    [SerializeField] float m_damping = 1.0f;
    [SerializeField] float m_frequency = 5.0f;

    private TargetJoint2D m_targetJoint;

    void Update () {
        Vector2 worldPos = MouseController.MousePosition;

        if (Input.GetMouseButtonDown (0)) {
            Collider2D collider = Physics2D.OverlapPoint (worldPos, m_DragLayers);
            if (!collider)
                return;

            Rigidbody2D body = collider.attachedRigidbody;
            if (!body)
                return;

            m_targetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
            m_targetJoint.dampingRatio = m_damping;
            m_targetJoint.frequency = m_frequency;

            m_targetJoint.anchor = m_targetJoint.transform.InverseTransformPoint (worldPos);
        } else if (Input.GetMouseButtonUp (0)) {
            Destroy (m_targetJoint);
            m_targetJoint = null;
            return;
        }

        if (m_targetJoint) {
            m_targetJoint.target = worldPos;
        }
    }
}