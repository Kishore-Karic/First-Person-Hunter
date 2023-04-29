using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponView : MonoBehaviour
    {
        private WeaponController weaponController;

        public void SetWeaponController(WeaponController _weaponController)
        {
            weaponController = _weaponController;
        }

        public Vector3 GetLocalRotation()
        {
            return weaponController.GetLocalRotation();
        }

        public ObjectType GetWeaponType()
        {
            return weaponController.GetWeaponType();
        }

        public void SetCrosshair(bool _value)
        {
            weaponController.SetCrosshair(_value);
        }

        public Transform GetCrosshairDotObject()
        {
            return weaponController.GetCrosshairDotObject();
        }

        public float GetNextShootTime()
        {
            return weaponController.GetNextShootTime();
        }
    }
}