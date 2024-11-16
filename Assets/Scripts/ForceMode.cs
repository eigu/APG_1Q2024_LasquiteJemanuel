using NaughtyAttributes;
using UnityEngine;

public class ForceMode : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private Vector3 _forceAmount;
    [SerializeField] private bool _isManual;

    private Vector3 _velocity;

    private bool m_isAddingForce;
    private bool m_isAddingAcceleration;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_isAddingForce) AddForce();

        if (m_isAddingAcceleration) AddAcceleration();
    }

    [Button]
    private void DoAddForce()
    {
        m_isAddingForce = true;
    }

    private void AddForce()
    {
        if (!_isManual)
        {
            _rigidBody.AddForce(_forceAmount, UnityEngine.ForceMode.Force);

            return;
        }

        _rigidBody.velocity += _forceAmount * Time.deltaTime / _rigidBody.mass;
    }

    [Button]
    private void DoAddAcceleration()
    {
        m_isAddingAcceleration = true;
    }

    private void AddAcceleration()
    {
        if (!_isManual)
        {
            _rigidBody.AddForce(_forceAmount, UnityEngine.ForceMode.Acceleration);
            
            return;
        }

        _rigidBody.velocity += _forceAmount * Time.deltaTime;
    }


    [Button]
    private void AddImpulse()
    {
        if (!_isManual)
        {
            _rigidBody.AddForce(_forceAmount, UnityEngine.ForceMode.Impulse);

            return;
        }

        _rigidBody.velocity += _forceAmount / _rigidBody.mass;
    }

    [Button]
    private void AddVelocity()
    {
        if (!_isManual)
        {
            _rigidBody.AddForce(_forceAmount, UnityEngine.ForceMode.VelocityChange);

            return;
        }

        _rigidBody.velocity += _forceAmount;
    }
}
