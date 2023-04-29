using FPHunter.Managers;
using FPHunter.Player;
using FPHunter.Weapon;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Service
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private PlayerModelData playerModelData;
        [field: SerializeField] public List<AnimatorController> AnimatorsList { get; private set; }
        [SerializeField] private WeaponService weaponService;

        private void Start()
        {
            new PlayerController(new PlayerModel(playerModelData), this, playerPrefab, transform, AnimatorsList);
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
    }
}