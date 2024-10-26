using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrapple : MonoBehaviour
{
    private Vector2 m_mousePosition;

    [SerializeField] private DistanceJoint2D m_grapple;
    [SerializeField] private LineRenderer m_grappleRender;

    private bool m_isGrappling;

    private void Update()
    {
        if (m_isGrappling)
        {
            m_grappleRender.enabled = true;

            m_grappleRender.SetPosition(0, transform.position);
            m_grappleRender.SetPosition(1, m_mousePosition);

            m_grapple.enabled = true;
            m_grapple.connectedAnchor = m_mousePosition;
        }
        else
        {
            m_grapple.enabled = false;
            m_grappleRender.enabled = false;
        }
    }

    public void Grapple(InputAction.CallbackContext context)
    {
        m_isGrappling = context.performed ? true : false;

        m_mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
