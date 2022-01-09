using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _content;
    [SerializeField]
    private Button _startButton;

    void Start()
    {
        _content.SetActive(true);
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        EventsBus.RaiseGameStarted();
        _content.SetActive(false);
    }
}
