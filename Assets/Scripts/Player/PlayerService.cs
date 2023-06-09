using FPHunter.Bullet;
using FPHunter.Enum;
using FPHunter.Managers;
using FPHunter.Weapon;
using System.Collections.Generic;
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
        [field: SerializeField] public List<RuntimeAnimatorController> AnimatorsList { get; private set; }

        private PlayerController playerController;

        private void Start()
        {
            SoundManager.Instance.StopMusic(Sounds.LobbyTheme);
            SoundManager.Instance.PlayMusic(Sounds.GameTheme);
            playerController = new PlayerController(new PlayerModel(playerModelData), this, playerPrefab, spawnPoints[GameManager.Instance.GetIndex()], AnimatorsList);
        }

        public WeaponView GetRightHandWeapon()
        {
            return weaponService.GetWeapon(GameManager.Instance.GetWeaponType());
        }

        public WeaponView GetLeftHandWeapon()
        {
            if(GameManager.Instance.GetWeaponType() == Enum.WeaponType.DoublePistol)
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