using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerController
    {
        private PlayerModel playerModel;
        private PlayerView playerView;
        private Rigidbody rigidBody;
        private Camera firstPersonCamera;

        public PlayerController(PlayerModel _playerModel, PlayerView _playerPrefab, Transform transform, AnimatorController animator)
        {
            playerModel= _playerModel;
            playerView = GameObject.Instantiate(_playerPrefab, transform);

            playerView.SetPlayerController(this);
            rigidBody = playerView.RigidBody;
            playerView.SetPlayerAnimator(animator);
            firstPersonCamera = playerView.FirstPersonCamera;
            firstPersonCamera.transform.eulerAngles =  new Vector3(playerModel.Zero, playerModel.Zero, playerModel.Zero);
        }

        public void Move(float movement)
        {
            rigidBody.velocity = playerView.transform.forward * movement * playerModel.MovementSpeed * Time.deltaTime;
        }

        public void RotateHorizontal(float horizontalRotation)
        {
            playerView.transform.Rotate(Vector3.up * horizontalRotation * playerModel.RotationSpeed * Time.deltaTime);
        }

        public void RotateVertical(float verticalRotation)
        {
            firstPersonCamera.transform.Rotate(Vector3.right * -verticalRotation * playerModel.RotationSpeed * Time.deltaTime);

            float currentAngle = firstPersonCamera.transform.localEulerAngles.x;

            bool isHigherThanRange = currentAngle > playerModel.FirstMaxAngle && currentAngle < playerModel.SecondMaxAngle;
            bool isLowerThanRange = currentAngle < playerModel.FirstMinAngle && currentAngle > playerModel.SecondMinAngle;

            if (isHigherThanRange)
            {
                firstPersonCamera.transform.localEulerAngles = new Vector3(Mathf.Clamp(currentAngle, playerModel.Zero, playerModel.FirstMaxAngle), playerModel.Zero, playerModel.Zero);
            }

            if (isLowerThanRange)
            {
                firstPersonCamera.transform.localEulerAngles = new Vector3(Mathf.Clamp(currentAngle, playerModel.FirstMinAngle, playerModel.FirstMinAngle), playerModel.Zero, playerModel.Zero);
            }
        }

        public float GetValueZero()
        {
            return playerModel.Zero;
        }
    }
}