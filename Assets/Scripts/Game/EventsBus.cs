using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsBus
{
    public static event Action GameStarted;
    public static void RaiseGameStarted()
    {
        GameStarted?.Invoke();
    }

    public static event Action ForceAccumStarted;
    public static void RaiseForceAccumStarted()
    {
        ForceAccumStarted?.Invoke();
    }

    public static event Action ForceAccumEnded;
    public static void RaiseForceAccumEnded()
    {
        ForceAccumEnded?.Invoke();
    }

    public static event Action<PetalType> PetalMoved;
    public static void RaisePetalMoved(PetalType type)
    {
        PetalMoved?.Invoke(type);
    }

    public static event Action RoundOver;
    public static void RaiseRoundOver()
    {
        RoundOver?.Invoke();
    }
}
