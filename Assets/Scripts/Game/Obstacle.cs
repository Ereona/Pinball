using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    private Tween _tween;
    private MeshRenderer _mesh;

    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag != "Player")
        {
            return;
        }
        if (_tween != null)
        {
            _tween.Kill(true);
            _tween = null;
        }
        _tween = _mesh.material.DOColor(Color.white, 0.2f).SetLoops(4, LoopType.Yoyo);
    }
}
