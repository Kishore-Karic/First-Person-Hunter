using FPHunter.StateMachine.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace FPHunter.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
        [field: SerializeField] public EnemyStateMachine EnemyStateMachine { get; private set; }

        [SerializeField] private SkinnedMeshRenderer meshRenderer;

        private EnemyController enemyController;

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        public void SetEnemyTexture(Texture texture)
        {
            meshRenderer.material.mainTexture = texture;
        }
    }
}