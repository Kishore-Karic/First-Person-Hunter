using FPHunter.Bullet;
using FPHunter.Managers;
using FPHunter.Weapon;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private PlayerModelData playerModelData;
        [SerializeField] private WeaponService weaponService;
        [SerializeField] private List<Vector3> spawnPoints;

        [field: SerializeField] public BulletService BulletService { get; private set; }
        [field: SerializeField] public List<AnimatorController> AnimatorsList { get; private set; }

        private PlayerController playerController;

        private void Start()
        {
            playerController = new PlayerController(new PlayerModel(playerModelData), this, playerPrefab, spawnPoints[GameManager.Instance.GetIndex()], AnimatorsList);
        }

        public WeaponView GetRightHandWeapon()
        {
            return weaponService.GetWeapon(GameManager.Instance.GetWeaponType());
        }

        public WeaponView GetLeftHandWeapon()
        {
            if(GameManager.Instance.GetWeaponType() == Enum.ObjectType.DoublePistol)
            {
                return weaponService.GetWeapon(GameManager.Instance.GetWeaponType());
            }
            else
            {
                return null;
            }
        }

        public Transform GetPlayerObject()
        {
            return playerController.GetPlayerViewTransform();
        }

        public void PlayerDead()
        {
            playerController.PlayerDead();
        }
    }
}