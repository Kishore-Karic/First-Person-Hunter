namespace FPHunter.Player
{
    public class PlayerModel
    {
        public float CrouchMovementSpeed { get; private set; }
        public float NormalMovementSpeed { get; private set; }
        public float RotationSpeed { get; private set; }
        public int Zero { get; private set; }
        public float FirstMaxAngle { get; private set; }
        public float SecondMaxAngle { get; private set; }
        public float FirstMinAngle { get; private set; }
        public float SecondMinAngle { get; private set; }
        public int BulletSpawnDelayInMicroSeconds { get; private set; }

        public PlayerModel(PlayerModelData playerModelData)
        {
            CrouchMovementSpeed = playerModelData.CrouchMovementSpeed;
            NormalMovementSpeed = playerModelData.NormalMovementSpeed;
            RotationSpeed = playerModelData.RotationSpeed;
            Zero = playerModelData.Zero;
            FirstMaxAngle = playerModelData.CameraFirstMaxAngle;
            SecondMaxAngle = playerModelData.CameraSecondMaxAngle;
            FirstMinAngle = playerModelData.CameraFirstMinAngle;
            SecondMinAngle = playerModelData.CameraSecondMinAngle;
            BulletSpawnDelayInMicroSeconds = playerModelData.BulletSpawnDelayInMicroSeconds;
        }

        public void SetMovementSpeed(float _speed)
        {
            NormalMovementSpeed -= _speed;
            CrouchMovementSpeed -= _speed;
        }
    }
}