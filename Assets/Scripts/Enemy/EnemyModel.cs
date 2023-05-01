using UnityEngine;

namespace FPHunter.Enemy 
{ 
    public class EnemyModel
    {
        public Texture EnemyTexture {  get; private set; }
        public float WalkSpeed { get; private set; }
        public float RunSpeed { get; private set; }
        public float IdleTime { get; private set; }
        public float PatrolRange { get; private set; }
        public float ChaseRange { get; private set; }
        public float AttackRange { get; private set; }
        public float Zero { get; private set; }
        public float SlowEffectTime { get; private set; }
        public float FrontView { get; private set; }

        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            EnemyTexture = enemyScriptableObject.Texture;
            WalkSpeed = enemyScriptableObject.WalkSpeed;
            RunSpeed = enemyScriptableObject.RunSpeed;
            IdleTime = enemyScriptableObject.IdleTime;
            PatrolRange = enemyScriptableObject.PatrolRange;
            ChaseRange = enemyScriptableObject.ChaseRange;
            AttackRange = enemyScriptableObject.AttackRange;
            Zero = enemyScriptableObject.Zero;
            SlowEffectTime = enemyScriptableObject.SlowEffectTime;
            FrontView = enemyScriptableObject.FrontView;
        }
    }
}