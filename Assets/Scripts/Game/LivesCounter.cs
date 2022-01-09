using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField]
    private GameSettings _settings;

    private int _count;

    private void Start()
    {
        EventsBus.GameStarted += EventsBus_GameStarted;
        EventsBus.RoundOver += EventsBus_RoundOver;
    }

    private void EventsBus_GameStarted()
    {
        _count = _settings.LivesCount - 1;
        EventsBus.RaiseLivesChanged(_count);
        EventsBus.RaiseRoundStarted();
    }

    private void EventsBus_RoundOver()
    {
        if (_count == 0)
        {
            EventsBus.RaiseGameOver();
        }
        else
        {
            _count--;
            EventsBus.RaiseLivesChanged(_count);
            EventsBus.RaiseRoundStarted();
        }
    }

    private void OnDestroy()
    {
        EventsBus.GameStarted -= EventsBus_GameStarted;
        EventsBus.RoundOver -= EventsBus_RoundOver;
    }
}
