using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponController
    {
        private WeaponModel weaponModel;
        private WeaponView weaponView;
        private WeaponService weaponService;
        private GameObject crosshair;

        public WeaponController(WeaponModel _weaponModel, WeaponService _weaponService, WeaponView _weaponView)
        {
            weaponModel = _weaponModel;
            weaponView = GameObject.Instantiate(_weaponView);
            weaponService = _weaponService;
            weaponView.SetWeaponController(this);

            crosshair = GameObject.Instantiate(weaponService.GetCrosshair((int)GetWeaponType()));
            crosshair.SetActive(false);
        }

        public WeaponView ReturnWeaponView()
        {
            return weaponView;
        }

        public Vector3 GetLocalRotation()
        {
            return weaponModel.LocalRotation;
        }

        public ObjectType GetWeaponType()
        {
            return weaponModel.ObjectType;
        }

        public void SetCrosshair(bool _value)
        {
            crosshair.SetActive(_value);
        }
    }
}