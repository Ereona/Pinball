using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesMenu : MonoBehaviour
{
    [SerializeField]
    private Text _count;

    void Start()
    {
        EventsBus.LivesChanged += EventsBus_LivesChanged;
        _count.text = "0";
    }

    private void EventsBus_LivesChanged(int obj)
    {
        _count.text = obj.ToString();
    }

    private void OnDestroy()
    {
        EventsBus.LivesChanged -= EventsBus_LivesChanged;
    }
}
