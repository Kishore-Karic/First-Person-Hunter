using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/New Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        public WeaponType WeaponType;
        public BulletType BulletType;
        public float WeaponWeight;
        public ScopeType ScopeType;
        public Vector3 LocalRotation;
        public float NextShootTime;
        public int Zero;
    }
}