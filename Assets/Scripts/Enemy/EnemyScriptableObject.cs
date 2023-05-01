using UnityEngine;

namespace FPHunter.Enemy
{
    [CreateAssetMenu(fileName = "Bear", menuName = "ScriptableObjects/New Bear")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public Texture Texture;
        public float IdleTime;
        public float WalkSpeed;
        public float RunSpeed;
        public float PatrolRange;
        public float ChaseRange;
        public float AttackRange;
        public float Zero;
        public float SlowEffectTime;
        public float FrontView;
    }
}