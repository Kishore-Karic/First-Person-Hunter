using FPHunter.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace FPHunter.StateMachine.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public float IdleTime { get; private set; }
        public float Zero { get; private set; }
        public float SlowEffectTime { get; private set; }
        public bool IsAttacked { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }

        private EnemyController enemyController;

        public IdleState IdleState { get; private set; }
        public PatrolState PatrolState { get; private set; }
        public ChaseState ChaseState { get; private set; }
        public AttackState AttackState { get; private set; }
        public DeadState DeadState { get; private set; }

        private void Update()
        {
            if(currentState != null)
            {
                currentState.OnUpdate();
            }
        }

        private void InitializeStates()
        {
            IdleState = new IdleState(this);
            PatrolState = new PatrolState(this);
            ChaseState = new ChaseState(this);
            AttackState = new AttackState(this);
            DeadState = new DeadState(this);
        }

        public void SetEnemyStateMachine(EnemyController _enemyController, float _idleTime, float _zero, float _slowEffectTime, NavMeshAgent _agent, Animator _animator)
        {
            enemyController = _enemyController;
            NavMeshAgent = _agent;
            Animator = _animator;

            IdleTime = _idleTime;
            Zero = _zero;
            SlowEffectTime = _slowEffectTime;
            IsAttacked = false;

            InitializeStates();

            SetState(IdleState);
        }

        public bool IsPlayerInAttackRange()
        {
            return enemyController.IsPlayerInAttackRange();
        }

        public bool IsPlayerInChaseRange()
        {
            return enemyController.IsPlayerInChaseRange();
        }

        public Vector3 GetPatrolDestination()
        {
            return enemyController.GetPatrolDestination();
        }

        public Transform GetPlayerTransform()
        {
            return enemyController.GetPlayerTransform();
        }

        public void SetWalkSpeed(bool _value)
        {
            enemyController.SetWalkSpeed(_value);
        }

        public void PlayerDead()
        {
            enemyController.PlayerDead();
        }

        public void EnemyDead()
        {
            SetState(DeadState);
        }

        public void GotDamage()
        {
            IsAttacked = true;
            SetState(ChaseState);
        }
    }
}