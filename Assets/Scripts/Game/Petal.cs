using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petal : MonoBehaviour
{
    [SerializeField]
    private GameSettings _settings;
    [SerializeField]
    private PetalType _type;

    private Rigidbody _body;
    private Sequence _s;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        EventsBus.PetalMoved += EventsBus_PetalMoved;
    }

    private void EventsBus_PetalMoved(PetalType obj)
    {
        if (obj != _type)
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        if (_s != null && _s.IsPlaying())
        {
            return;
        }
        _s = DOTween.Sequence();
        float endRot = _settings.PetalEndRotation;
        float startRot = _settings.PetalStartRotation;
        if (_type == PetalType.Left)
        {
            endRot *= -1;
            startRot *= -1;
        }
        _s.Append(_body.DORotate(new Vector3(0, endRot, 0), _settings.PetalRotationDuration, RotateMode.Fast).SetEase(Ease.InExpo));
        _s.Append(_body.DORotate(new Vector3(0, startRot, 0), _settings.PetalRotationDuration, RotateMode.Fast).SetEase(Ease.InExpo));
    }

    private void OnDestroy()
    {
        EventsBus.PetalMoved -= EventsBus_PetalMoved;
    }
}
