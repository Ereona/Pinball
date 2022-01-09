using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private GameSettings _settings;
    [SerializeField]
    private GameObject _ballPrefab;
    [SerializeField]
    private Transform _startPos;

    private Rigidbody _ball;
    private float _startTime;

    private void Start()
    {
        EventsBus.RoundStarted += EventsBus_RoundStarted;
        EventsBus.ForceAccumStarted += EventsBus_ForceAccumStarted;
        EventsBus.ForceAccumEnded += EventsBus_ForceAccumEnded;
    }

    private void EventsBus_RoundStarted()
    {
        GameObject ball = Instantiate(_ballPrefab);
        ball.transform.position = _startPos.position;
        _ball = ball.GetComponent<Rigidbody>();
    }

    private void EventsBus_ForceAccumStarted()
    {
        if (_ball == null)
        {
            return;
        }
        _startTime = Time.time;
    }

    private void EventsBus_ForceAccumEnded()
    {
        if (_ball == null)
        {
            return;
        }
        float force = Mathf.Min(_settings.StarterMaxForce, (Time.time - _startTime) * _settings.StarterForceMultiplier);
        _ball.AddForce(force, 0, 0);
        _ball = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_ball != null)
        {
            return;
        }
        if (other.tag == "Player")
        {
            _ball = other.GetComponent<Rigidbody>();
            _ball.velocity = Vector3.zero;
        }
    }

    private void OnDestroy()
    {
        EventsBus.RoundStarted -= EventsBus_RoundStarted;
        EventsBus.ForceAccumStarted -= EventsBus_ForceAccumStarted;
        EventsBus.ForceAccumEnded -= EventsBus_ForceAccumEnded;
    }
}
