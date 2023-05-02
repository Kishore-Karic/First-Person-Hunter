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
        public float CloseRange { get; private set; }
        public float ChaseRange { get; private set; }
        public float AttackRange { get; private set; }
        public float Zero { get; private set; }
        public float SlowEffectTime { get; private set; }
        public float FrontView { get; private set; }
        public float BackView { get; private set; }
        public float EyesDamageMultiplier { get; private set; }
        public float HeadDamageMultiplier { get; private set; }
        public float BodyDamageMultiplier { get; private set; }
        public float LegsDamageMultiplier { get; private set; }
        public float DestroyTime { get; private set; }

        public float CurrentHealth { get; private set; }
        private float TotalHealth;


        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            EnemyTexture = enemyScriptableObject.Texture;
            WalkSpeed = enemyScriptableObject.WalkSpeed;
            RunSpeed = enemyScriptableObject.RunSpeed;
            IdleTime = enemyScriptableObject.IdleTime;
            PatrolRange = enemyScriptableObject.PatrolRange;
            CloseRange = enemyScriptableObject.CloseRange;
            ChaseRange = enemyScriptableObject.ChaseRange;
            AttackRange = enemyScriptableObject.AttackRange;
            Zero = enemyScriptableObject.Zero;
            SlowEffectTime = enemyScriptableObject.SlowEffectTime;
            FrontView = enemyScriptableObject.FrontView;
            BackView = enemyScriptableObject.BackView;
            EyesDamageMultiplier = enemyScriptableObject.EyesDamageMultiplier;
            HeadDamageMultiplier = enemyScriptableObject.HeadDamageMultiplier;
            BodyDamageMultiplier = enemyScriptableObject.BodyDamageMultiplier;
            LegsDamageMultiplier = enemyScriptableObject.LegsDamageMultiplier;
            DestroyTime = enemyScriptableObject.DestroyTime;

            TotalHealth = enemyScriptableObject.TotalHealth;
            CurrentHealth = TotalHealth;
        }

        public void SetEnemyHealth(float _value)
        {
            CurrentHealth = _value;
        }
    }
}