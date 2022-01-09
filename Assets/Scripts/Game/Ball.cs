using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameSettings _settings;

    private Rigidbody _body;
    private Vector3 _lastFrameVelocity;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _body.AddForce(-_settings.BallGravitationForce * Time.fixedDeltaTime, 0, 0);
    }

    private void Update()
    {
        if (_body.velocity.magnitude > _settings.BallMaxVelocity)
        {
            _body.velocity *= _settings.BallMaxVelocity / _body.velocity.magnitude;
        }
        _lastFrameVelocity = _body.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Petal>() == null)
        {
            Bounce(collision.contacts[0].normal);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = _lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(_lastFrameVelocity.normalized, collisionNormal);
        _body.velocity = direction * speed * _settings.BallBounciness;
    }
}
