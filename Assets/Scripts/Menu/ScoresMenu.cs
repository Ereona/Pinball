using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresMenu : MonoBehaviour
{
    [SerializeField]
    private Text _count;

    void Start()
    {
        EventsBus.ScoreChanged += EventsBus_ScoreChanged;
        _count.text = "0";
    }

    private void EventsBus_ScoreChanged(int obj)
    {
        _count.text = obj.ToString();
    }

    void OnDestroy()
    {
        EventsBus.ScoreChanged -= EventsBus_ScoreChanged;
    }
}
