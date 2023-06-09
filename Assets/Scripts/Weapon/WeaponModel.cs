using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponModel
    {
        public WeaponType WeaponType { get; private set; }
        public BulletType BulletType { get; private set; }
        public float WeaponWeight { get; private set; }
        public ScopeType ScopeType { get; private set; }
        public Vector3 LocalRotation { get; private set; }
        public float NextShootTime { get; private set; }
        public int Zero { get; private set; }

        public WeaponModel(WeaponScriptableObject weaponScriptableObject)
        {
            WeaponType = weaponScriptableObject.WeaponType;
            BulletType = weaponScriptableObject.BulletType;
            WeaponWeight = weaponScriptableObject.WeaponWeight;
            ScopeType = weaponScriptableObject.ScopeType;
            LocalRotation = weaponScriptableObject.LocalRotation;
            NextShootTime = weaponScriptableObject.NextShootTime;
            Zero = weaponScriptableObject.Zero;
        }
    }
}