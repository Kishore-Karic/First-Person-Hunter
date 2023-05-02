using FPHunter.Managers;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public GameObject FirstPersonCamera { get; private set; }
        [field: SerializeField] public GameObject SniperCamera { get; private set; }
        [field: SerializeField] public Transform RightHandGunSlot { get; private set; }
        [field: SerializeField] public Transform LeftHandGunSlot { get; private set; }
        [field: SerializeField] public Transform CrosshairDot { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }

        [SerializeField] private Camera firstPersonCamera;
        [SerializeField] private Camera sniperCamera;

        private PlayerController playerController;
        private float moveZAxis;
        private float moveXAxis;
        private float horizontalRotation;
        private float verticalRotation;
        private float mouseScroll;
        private float zero;
        private float nextShootTime;
        private float currentShootTime;
        private bool isDead;
        public bool IsAiming { get; private set; }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
            zero = playerController.GetValueZero();
            isDead = false;
        }

        private void Update()
        {
            if (!isDead)
            {
                Movement();

                if (moveZAxis != zero)
                {
                    playerController.MoveVerticle(moveZAxis);
                }

                if(moveXAxis != zero)
                {
                    playerController.MoveHorizontal(moveXAxis);
                }

                if (horizontalRotation != zero)
                {
                    playerController.RotateHorizontal(horizontalRotation);
                }

                if (verticalRotation != zero)
                {
                    playerController.RotateVertical(verticalRotation);
                }

                if (Input.GetKey(KeyCode.Mouse1) && moveZAxis == zero && moveXAxis == zero)
                {
                    playerController.AimWeapon();
                    IsAiming = true;
                }
                else
                {
                    playerController.PutDownWeapon();
                    IsAiming = false;
                }

                currentShootTime += Time.deltaTime;
                if (IsAiming && currentShootTime > nextShootTime && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    currentShootTime = zero;
                    Animator.SetTrigger("Attack");
                    playerController.SpawnBullet();
                }

                if (IsAiming && mouseScroll > zero)
                {
                    playerController.ZoomInCamera();
                }
                else if(IsAiming && mouseScroll < zero)
                {
                    playerController.ZoomOutCamera();
                }
            }
        }

        private void Movement()
        {
            moveZAxis = Input.GetAxisRaw("Vertical");
            moveXAxis = Input.GetAxisRaw("Horizontal");
            horizontalRotation = Input.GetAxisRaw("Mouse X");
            verticalRotation = Input.GetAxisRaw("Mouse Y");
            mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        }

        public void SetCamera(bool _fpsCamera, bool _sniperCamera)
        {
            firstPersonCamera.enabled = _fpsCamera;
            sniperCamera.enabled = _sniperCamera;
        }

        public void SetPlayerAnimator(AnimatorController _animatorController)
        {
            Animator.runtimeAnimatorController = _animatorController;
        }

        public void DestroyThis(GameObject gameObject)
        {
            Destroy(gameObject);
        }

        public void SetNextShootTime(float _time)
        {
            nextShootTime = _time;
            currentShootTime = nextShootTime;
        }

        public Camera GetSniperCamera()
        {
            return sniperCamera;
        }

        public void PlayerDead()
        {
            isDead = true;
            StartCoroutine(DestroyTime());
        }

        IEnumerator DestroyTime()
        {
            yield return new WaitForSeconds(playerController.GetDestroyTime());
            GameManager.Instance.PlayerDead();
        }
    }
}