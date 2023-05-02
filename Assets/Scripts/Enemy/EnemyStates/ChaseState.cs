namespace FPHunter.StateMachine.Enemy
{
    public class ChaseState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public ChaseState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("Run Forward", true);
            enemyStateMachine.SetWalkSpeed(false);
            enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void OnUpdate()
        {
            if (enemyStateMachine.IsPlayerInAttackRange())
            {
                stateMachine.SetState(enemyStateMachine.AttackState);
            }
            else if (enemyStateMachine.IsAttacked)
            {
                enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.GetPlayerTransform().position);
            }
            else if (enemyStateMachine.IsPlayerInChaseRange())
            {
                enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.GetPlayerTransform().position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.IdleState);
            }
        }

        public override void OnStateExit()
        {
            enemyStateMachine.Animator.SetBool("Run Forward", false);
        }
    }
}