using FPHunter.Service;
using FPHunter.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private GameObject camera;
        private bool isDoubleWeaponAvailable;
        private bool isSniperWeapon;

        public PlayerController(PlayerModel _playerModel, PlayerService _playerService, PlayerView _playerPrefab, Transform transform, List<AnimatorController> animatorsList)
        {
            playerModel= _playerModel;
            playerView = GameObject.Instantiate(_playerPrefab, transform);
            playerService = _playerService;

            playerView.SetPlayerController(this);
            rigidBody = playerView.RigidBody;
            camera = playerView.FirstPersonCamera;
            camera.transform.localRotation =  Quaternion.Euler(playerModel.Zero, playerModel.Zero, playerModel.Zero);

            RightHandWeaponView = playerService.GetRightHandWeapon();
            LeftHandWeaponView = playerService.GetLeftHandWeapon();

            playerModel.SetMovementSpeed(RightHandWeaponView.GetWeaponWeight());

            if(LeftHandWeaponView == null)
            {
                isDoubleWeaponAvailable = false;
            }
            else
            {
                isDoubleWeaponAvailable = true;
                playerModel.SetMovementSpeed(LeftHandWeaponView.GetWeaponWeight());
            }


            if(RightHandWeaponView.GetWeaponType() == Enum.ObjectType.Sniper)
            {
                isSniperWeapon = true;
            }
            else
            {
                isSniperWeapon = false;
            }

            PlaceGunInHand();
            playerView.SetNextShootTime(RightHandWeaponView.GetNextShootTime());
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
            playerView.SetPlayerAnimator(playerService.AnimatorsList[animatorListIndex]);
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
            if (isSniperWeapon && playerView.IsAiming)
            {
                camera = playerView.SniperCamera;
            }
            else
            {
                camera = playerView.FirstPersonCamera;
            }

            camera.transform.Rotate(Vector3.right * -verticalRotation * playerModel.RotationSpeed * Time.deltaTime);

            float currentAngle = camera.transform.localEulerAngles.x;

            bool isHigherThanRange = currentAngle > playerModel.FirstMaxAngle && currentAngle < playerModel.SecondMaxAngle;
            bool isLowerThanRange = currentAngle < playerModel.FirstMinAngle && currentAngle > playerModel.SecondMinAngle;

            if (isHigherThanRange)
            {
                camera.transform.localEulerAngles = new Vector3(Mathf.Clamp(currentAngle, playerModel.Zero, playerModel.FirstMaxAngle), playerModel.Zero, playerModel.Zero);
            }

            if (isLowerThanRange)
            {
                camera.transform.localEulerAngles = new Vector3(Mathf.Clamp(currentAngle, playerModel.FirstMinAngle, playerModel.FirstMinAngle), playerModel.Zero, playerModel.Zero);
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

        public void AimWeapon()
        {
            RightHandWeaponView.SetCrosshair(true);
            playerView.Animator.SetBool("Aiming", true);

            if (isSniperWeapon)
            {
                playerView.SetCamera(false, true);
            }

            RightHandWeaponView.transform.LookAt(playerView.CrosshairDot);
            
            if (isDoubleWeaponAvailable)
            {
                LeftHandWeaponView.transform.LookAt(playerView.CrosshairDot);
            }
        }

        public void PutDownWeapon()
        {
            RightHandWeaponView.SetCrosshair(false);
            playerView.Animator.SetBool("Aiming", false);

            if (isSniperWeapon)
            {
                playerView.SetCamera(true, false);
            }

            RightHandWeaponView.transform.localRotation = Quaternion.Euler(RightHandWeaponView.GetLocalRotation());

            if (isDoubleWeaponAvailable)
            {
                LeftHandWeaponView.transform.localRotation = Quaternion.Euler(RightHandWeaponView.GetLocalRotation());
            }
        }

        public void SpawnBullet()
        {
            if (isDoubleWeaponAvailable)
            {
                SpawnBulletWithDelay();
            }

            playerService.BulletService.SpawnBullet(RightHandWeaponView.GetBulletType(), playerView.CrosshairDot, playerView.CrosshairDot.rotation);
        }

        private async void SpawnBulletWithDelay()
        {
            playerService.BulletService.SpawnBullet(RightHandWeaponView.GetBulletType(), playerView.CrosshairDot, playerView.CrosshairDot.rotation);

            await Task.Delay(playerModel.BulletSpawnDelayInMicroSeconds);
        }

        public float GetValueZero()
        {
            return playerModel.Zero;
        }
    }
}