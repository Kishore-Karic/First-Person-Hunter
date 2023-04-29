using FPHunter.Service;
using FPHunter.Weapon;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerController
    {
        public WeaponView RightHandWeaponView { get; private set; }
        public WeaponView LeftHandWeaponView { get; private set; }

        private PlayerModel playerModel;
        private PlayerView playerView;
        private PlayerService playerService;
        private Rigidbody rigidBody;
        private Camera firstPersonCamera;
        private bool isDoubleWeaponAvailable;

        public PlayerController(PlayerModel _playerModel, PlayerService _playerService, PlayerView _playerPrefab, Transform transform, List<AnimatorController> animatorsList)
        {
            playerModel= _playerModel;
            playerView = GameObject.Instantiate(_playerPrefab, transform);
            playerService = _playerService;

            playerView.SetPlayerController(this);
            rigidBody = playerView.RigidBody;
            playerView.SetPlayerAnimator(animatorsList[playerModel.Zero]);
            firstPersonCamera = playerView.FirstPersonCamera;
            firstPersonCamera.transform.localRotation =  Quaternion.Euler(playerModel.Zero, playerModel.Zero, playerModel.Zero);

            RightHandWeaponView = playerService.GetRightHandWeapon();
            LeftHandWeaponView = playerService.GetLeftHandWeapon();

            if(LeftHandWeaponView == null)
            {
                isDoubleWeaponAvailable = false;
            }
            else
            {
                isDoubleWeaponAvailable = true;
            }

            PlaceGunInHand();
        }

        private void PlaceGunInHand()
        {
            if (playerView.RightHandGunSlot.childCount > playerModel.Zero)
            {
                playerView.DestroyThis(playerView.RightHandGunSlot.GetChild(playerModel.Zero).gameObject);
            }
            if (playerView.LeftHandGunSlot.childCount > playerModel.Zero)
            {
                playerView.DestroyThis(playerView.LeftHandGunSlot.GetChild(playerModel.Zero).gameObject);
            }

            if (isDoubleWeaponAvailable)
            {
                LeftHandWeaponView.gameObject.transform.SetParent(playerView.LeftHandGunSlot);
                LeftHandWeaponView.gameObject.transform.localPosition = Vector3.zero;
                LeftHandWeaponView.gameObject.transform.localRotation = Quaternion.Euler(LeftHandWeaponView.GetLocalRotation());
            }

            RightHandWeaponView.gameObject.transform.SetParent(playerView.RightHandGunSlot);
            RightHandWeaponView.gameObject.transform.localPosition = Vector3.zero;
            RightHandWeaponView.gameObject.transform.localRotation = Quaternion.Euler(RightHandWeaponView.GetLocalRotation());
                
            int animatorListIndex = (int)RightHandWeaponView.GetWeaponType();
            playerView.SetPlayerAnimator(playerService.AnimatorsList[++animatorListIndex]);
        }

        public void Move(float movement)
        {
            float currentMovementSpeed;

            if (playerView.IsCrouching)
            {
                currentMovementSpeed = playerModel.CrouchMovementSpeed;
            }
            else
            {
                currentMovementSpeed = playerModel.NormalMovementSpeed;
            }

            rigidBody.velocity = playerView.transform.forward * movement * currentMovementSpeed * Time.deltaTime;
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

        public void PlayerIsStanding()
        {
            playerView.Animator.SetBool("Squat", false);
        }

        public void PlayerIsCrouching()
        {
            playerView.Animator.SetBool("Squat", true);
        }

        public float GetValueZero()
        {
            return playerModel.Zero;
        }
    }
}