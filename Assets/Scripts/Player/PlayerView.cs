using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Camera FirstPersonCamera { get; private set; }
        [field: SerializeField] public Transform RightHandGunSlot { get; private set; }
        [field: SerializeField] public Transform LeftHandGunSlot { get; private set; }
        [field: SerializeField] public Transform Dot { get; private set; }

        private PlayerController playerController;
        private float movement;
        private float horizontalRotation;
        private float verticalRotation;
        private float zero;
        private float nextShootTime;
        private float currentShootTime;
        private bool isAiming;
        
        public bool IsCrouching { get; private set; }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
            zero = playerController.GetValueZero();
        }

        private void Update()
        {
            Movement();

            if(movement != zero)
            {
                playerController.Move(movement);
            }

            if(horizontalRotation != zero)
            {
                playerController.RotateHorizontal(horizontalRotation);
            }

            if(verticalRotation != zero)
            {
                playerController.RotateVertical(verticalRotation);
            }

            if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                IsCrouching = true;
                playerController.PlayerIsCrouching();
            }
            else
            {
                IsCrouching = false;
                playerController.PlayerIsStanding();
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                playerController.AimWeapon();
                isAiming = true;
            }
            else
            {
                playerController.PutDownWeapon();
                isAiming = false;
            }

            currentShootTime += Time.deltaTime;
            if (isAiming && currentShootTime > nextShootTime && Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentShootTime = zero;
                Animator.SetTrigger("Attack");
            }
        }

        private void Movement()
        {
            movement = Input.GetAxisRaw("Vertical");
            horizontalRotation = Input.GetAxisRaw("Mouse X");
            verticalRotation = Input.GetAxisRaw("Mouse Y");
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
        }
    }
}