using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponModel
    {
        public ObjectType ObjectType { get; private set; }
        public float WeaponWeight { get; private set; }
        public ScopeType ScopeType { get; private set; }
        public Vector3 LocalRotation { get; private set; }

        public WeaponModel(WeaponScriptableObject weaponScriptableObject)
        {
            ObjectType = weaponScriptableObject.ObjectType;
            WeaponWeight = weaponScriptableObject.WeaponWeight;
            ScopeType = weaponScriptableObject.ScopeType;
            LocalRotation = weaponScriptableObject.LocalRotation;
        }
    }
}