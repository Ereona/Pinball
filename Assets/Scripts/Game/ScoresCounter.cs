using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    private static int _score;

    public static int Score
    {
        get
        {
            return _score;
        }
    }

    public static int MaxScore
    {
        get
        {
            return PlayerPrefs.GetInt("MaxScore", 0);
        }
        private set
        {
            PlayerPrefs.SetInt("MaxScore", value);
        }
    }

    private void Start()
    {
        EventsBus.GameStarted += EventsBus_GameStarted;
        EventsBus.ScoreAdded += EventsBus_ScoreAdded;
    }

    private void EventsBus_GameStarted()
    {
        _score = 0;
        EventsBus.RaiseScoreChanged(_score);
    }

    private void EventsBus_ScoreAdded(int obj)
    {
        _score += obj; 
        if (_score > MaxScore)
        {
            MaxScore = _score;
        }
        EventsBus.RaiseScoreChanged(_score);
    }

    private void OnDestroy()
    {
        EventsBus.GameStarted -= EventsBus_GameStarted;
        EventsBus.ScoreAdded -= EventsBus_ScoreAdded;
    }
}
