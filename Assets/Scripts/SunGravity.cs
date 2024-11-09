using System.Collections.Generic;
using UnityEngine;

public class SunGravity : MonoBehaviour
{
    [SerializeField] private Collider2D[] _planets;

    [SerializeField] private float _minimumDistance;
    [SerializeField] private float _maximumDistance;

    [SerializeField] private float _intensity;

    [SerializeField] private LayerMask _planetLayer;

    private void Update()
    {
        _planets = Physics2D.OverlapCircleAll(transform.position, _minimumDistance, _planetLayer);

        foreach (Collider2D planet in _planets)
        {
            var distance = transform.position - planet.transform.position;

            var reverseDistance = planet.transform.position - transform.position;

            var variableIntensity = distance.magnitude > _maximumDistance ?
                _intensity * (1f - (Vector2.Distance(transform.position + (reverseDistance.normalized * _maximumDistance), planet.transform.position) / _minimumDistance)) :
                _intensity;

            planet.attachedRigidbody.AddForce(distance.normalized * variableIntensity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _minimumDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _maximumDistance);
    }
}
