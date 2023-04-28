using System;
using UnityEngine;

namespace FPHunter.Player
{
    [Serializable]
    public class PlayerModelData
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float Zero { get; private set; }
        [field: SerializeField] public float CameraFirstMaxAngle { get; private set; }
        [field: SerializeField] public float CameraSecondMaxAngle { get; private set; }
        [field: SerializeField] public float CameraFirstMinAngle { get; private set; }
        [field: SerializeField] public float CameraSecondMinAngle { get; private set; }
    }
}