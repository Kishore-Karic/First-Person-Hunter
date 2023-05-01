namespace FPHunter.StateMachine.Enemy
{
    public class DeadState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public DeadState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }
    }
}