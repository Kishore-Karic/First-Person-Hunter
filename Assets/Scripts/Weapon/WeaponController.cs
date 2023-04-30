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

            if (!weaponService.IsCrosshairCreated)
            {
                crosshair = GameObject.Instantiate(weaponService.GetCrosshair((int)GetWeaponType()));
                crosshair.SetActive(false);
                weaponService.SetIsCrosshairCreated(true);
            }
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

        public float GetNextShootTime()
        {
            return weaponModel.NextShootTime;
        }

        public BulletType GetBulletType()
        {
            return weaponModel.BulletType;
        }

        public float GetWeaponWeight()
        {
            return weaponModel.WeaponWeight;
        }
    }
}