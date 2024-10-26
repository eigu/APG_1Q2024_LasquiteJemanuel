using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _velocityMultiplier;

    private Vector2 m_inputVector;

    private bool m_isJumping;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_rigidBody.velocity = new Vector2(m_inputVector.x * _velocityMultiplier, m_rigidBody.velocity.y);

        if (m_isJumping) m_rigidBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    public void Move(InputAction.CallbackContext context)
    {
        m_inputVector = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        m_isJumping = context.performed ? true : false;
    }
}
