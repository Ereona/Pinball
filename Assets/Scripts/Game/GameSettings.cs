using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Ball Settings")]
    public float BallGravitationForce;
    public float BallMaxVelocity;
    public float BallBounciness;

    [Header("Petal Settings")]
    public float PetalStartRotation;
    public float PetalEndRotation;
    public float PetalRotationDuration;

    [Header("Starter Settings")]
    public float StarterForceMultiplier;
    public float StarterMaxForce;
}
