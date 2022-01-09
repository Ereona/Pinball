using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _content;
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _maxScore;
    [SerializeField]
    private Button _restartButton;

    private void Start()
    {
        _content.SetActive(false);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        EventsBus.GameOver += EventsBus_GameOver;
    }

    private void EventsBus_GameOver()
    {
        _content.SetActive(true);
        _score.text = ScoresCounter.Score.ToString();
        _maxScore.text = ScoresCounter.MaxScore.ToString();
    }

    private void OnRestartButtonClick()
    {
        _content.SetActive(false);
        EventsBus.RaiseGameStarted();
    }

    private void OnDestroy()
    {
        EventsBus.GameOver -= EventsBus_GameOver;
    }
}
