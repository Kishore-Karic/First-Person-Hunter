namespace FPHunter.Player
{
    public class PlayerModel
    {
        public float MovementSpeed { get; private set; }
        public float RotationSpeed { get; private set; }
        public int Zero { get; private set; }
        public float FirstMaxAngle { get; private set; }
        public float SecondMaxAngle { get; private set; }
        public float FirstMinAngle { get; private set; }
        public float SecondMinAngle { get; private set; }
        public int BulletSpawnDelayInMicroSeconds { get; private set; }
        public float DestroyTime { get; private set; }
        public float CameraScrollMinValue { get; private set; }
        public float CameraScrollMaxValue { get; private set; }

        public PlayerModel(PlayerModelData playerModelData)
        {
            MovementSpeed = playerModelData.MovementSpeed;
            RotationSpeed = playerModelData.RotationSpeed;
            Zero = playerModelData.Zero;
            FirstMaxAngle = playerModelData.CameraFirstMaxAngle;
            SecondMaxAngle = playerModelData.CameraSecondMaxAngle;
            FirstMinAngle = playerModelData.CameraFirstMinAngle;
            SecondMinAngle = playerModelData.CameraSecondMinAngle;
            BulletSpawnDelayInMicroSeconds = playerModelData.BulletSpawnDelayInMicroSeconds;
            DestroyTime = playerModelData.DestroyTime;
            CameraScrollMinValue = playerModelData.CameraScrollMinValue;
            CameraScrollMaxValue = playerModelData.CameraScrollMaxValue;
        }

        public void SetMovementSpeed(float _speed)
        {
            MovementSpeed -= _speed;
        }
    }
}