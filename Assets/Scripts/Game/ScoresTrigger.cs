using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresTrigger : MonoBehaviour
{
    [SerializeField]
    private int _scoresCount;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag != "Player")
        {
            return;
        }
        EventsBus.RaiseScoreAdded(_scoresCount);
    }
}
