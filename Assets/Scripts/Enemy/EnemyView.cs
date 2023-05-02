using FPHunter.Enum;
using FPHunter.Managers;
using FPHunter.StateMachine.Enemy;
using System.Collections;
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

        public void GotDamage(BodyArea bodyArea, float damageValue)
        {
            enemyController.GotDamage(bodyArea, damageValue);
        }

        public void DestroyObject(float _time)
        {
            StartCoroutine(StartDestroyTimer(_time));
        }

        IEnumerator StartDestroyTimer(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
            GameManager.Instance.PlayerWon();
        }
    }
}