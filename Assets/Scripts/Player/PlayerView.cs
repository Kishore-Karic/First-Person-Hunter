using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }
        [SerializeField] private Animator animator;
        [field: SerializeField] public Camera FirstPersonCamera { get; private set; }

        private PlayerController playerController;
        private float movement;
        private float horizontalRotation;
        private float verticalRotation;
        private float zero;

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
        }

        private void Movement()
        {
            movement = Input.GetAxisRaw("Vertical");
            horizontalRotation = Input.GetAxisRaw("Mouse X");
            verticalRotation = Input.GetAxisRaw("Mouse Y");
        }

        public void SetPlayerAnimator(AnimatorController _animatorController)
        {
            animator.runtimeAnimatorController = _animatorController;
        }
    }
}