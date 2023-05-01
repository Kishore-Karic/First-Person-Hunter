using UnityEngine;

namespace FPHunter.StateMachine.Enemy
{
    public class AttackState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public AttackState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.PlayerDead();
            enemyStateMachine.NavMeshAgent.isStopped = true;
            Time.timeScale = enemyStateMachine.SlowEffectTime;
            enemyStateMachine.Animator.SetBool("Attack1", true);
        }
    }
}