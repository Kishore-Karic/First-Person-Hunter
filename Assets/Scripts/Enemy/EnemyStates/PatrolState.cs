namespace FPHunter.StateMachine.Enemy
{
    public class PatrolState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public PatrolState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.Animator.SetBool("WalkForward", true);
            enemyStateMachine.SetWalkSpeed(true);
            enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.GetPatrolDestination());
            enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void OnUpdate()
        {
            if (enemyStateMachine.IsPlayerInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
            else if (enemyStateMachine.NavMeshAgent.remainingDistance <= enemyStateMachine.NavMeshAgent.stoppingDistance)
            {
                stateMachine.SetState(enemyStateMachine.IdleState);
            }
        }

        public override void OnStateExit()
        {
            enemyStateMachine.Animator.SetBool("WalkForward", false);
        }
    }
}