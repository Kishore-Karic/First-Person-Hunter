using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Bullet
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/New Bullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType BulletType;
        public float Damage;
        public float MovementSpeed;
        public float DestroyTime;
    }
}