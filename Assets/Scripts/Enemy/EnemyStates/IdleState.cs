using UnityEngine;

namespace FPHunter.StateMachine.Enemy
{
    public class IdleState : BaseState
    {
        private float idleTime;
        private float patrolTime;
        private float defaultPatrolTime;
        private EnemyStateMachine enemyStateMachine;

        public IdleState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
            idleTime = enemyStateMachine.IdleTime;
            defaultPatrolTime = enemyStateMachine.Zero;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("Idle", true);
            enemyStateMachine.NavMeshAgent.isStopped = true;
            patrolTime = defaultPatrolTime;
        }

        public override void OnUpdate()
        {
            patrolTime += Time.deltaTime;
            if (patrolTime > idleTime)
            {
                stateMachine.SetState(enemyStateMachine.PatrolState);
            }
            else if (enemyStateMachine.IsPlayerInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
        }

        public override void OnStateExit()
        {
            enemyStateMachine.Animator.SetBool("Idle", false);
        }
    }
}