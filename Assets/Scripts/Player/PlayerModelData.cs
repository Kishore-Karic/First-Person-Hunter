using System;
using UnityEngine;

namespace FPHunter.Player
{
    [Serializable]
    public class PlayerModelData
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public int Zero { get; private set; }
        [field: SerializeField] public float CameraFirstMaxAngle { get; private set; }
        [field: SerializeField] public float CameraSecondMaxAngle { get; private set; }
        [field: SerializeField] public float CameraFirstMinAngle { get; private set; }
        [field: SerializeField] public float CameraSecondMinAngle { get; private set; }
        [field: SerializeField] public int BulletSpawnDelayInMicroSeconds { get; private set; }
        [field: SerializeField] public float DestroyTime { get; private set; }
        [field: SerializeField] public float CameraScrollMinValue { get; private set; }
        [field: SerializeField] public float CameraScrollMaxValue { get; private set; }
    }
}