using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventsBus.RaiseForceAccumStarted();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            EventsBus.RaiseForceAccumEnded();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EventsBus.RaisePetalMoved(PetalType.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EventsBus.RaisePetalMoved(PetalType.Right);
        }
    }
}
