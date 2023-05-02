using FPHunter.Enum;
using FPHunter.StateMachine.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace FPHunter.Enemy
{
    public class EnemyController
    {
        private EnemyModel enemyModel;
        private EnemyService enemyService;
        private EnemyView enemyView;
        private EnemyStateMachine enemyStateMachine;
        private Transform playerTransform;

        public EnemyController(EnemyModel _enemyModel, EnemyService _enemyService, EnemyView _enemyView, Vector3 spawnPosition)
        {
            enemyModel = _enemyModel;
            enemyService = _enemyService;
            enemyView = GameObject.Instantiate(_enemyView);
            enemyView.transform.position = spawnPosition;

            enemyView.SetEnemyController(this);
            enemyView.SetEnemyTexture(enemyModel.EnemyTexture);
            enemyStateMachine = enemyView.EnemyStateMachine;
            enemyStateMachine.SetEnemyStateMachine(this, enemyModel.IdleTime, enemyModel.Zero, enemyModel.SlowEffectTime, enemyView.NavMeshAgent, enemyView.Animator);

            playerTransform = enemyService.GetPlayerObject();
        }

        public void PlayerDead()
        {
            enemyView.transform.LookAt(playerTransform);
            enemyService.PlayerDead();
        }

        public Transform GetPlayerTransform()
        {
            return playerTransform;
        }

        public void SetWalkSpeed(bool _value)
        {
            if (_value)
            {
                enemyView.NavMeshAgent.speed = enemyModel.WalkSpeed;
            }
            else
            {
                enemyView.NavMeshAgent.speed = enemyModel.RunSpeed;
            }
        }

        public bool IsPlayerInAttackRange()
        {
            if (playerTransform != null)
            {
                return Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.AttackRange;
            }
            return false;
        }

        public bool IsPlayerInChaseRange()
        {
            if (playerTransform != null)
            {
                if(Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.CloseRange)
                {
                    return true;
                }

                if(Vector3.Distance(enemyView.transform.position, playerTransform.position) < enemyModel.ChaseRange)
                {
                    Vector3 dirToTarget = Vector3.Normalize(playerTransform.position - enemyView.transform.position);
                    float viewDistance = Vector3.Dot(enemyView.transform.forward, dirToTarget);

                    if(viewDistance > enemyModel.FrontView || viewDistance < enemyModel.BackView)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public Vector3 GetPatrolDestination()
        {
            bool pointFound = false;
            Vector3 finalPosition = Vector3.zero;
            NavMeshHit hit;

            while (pointFound != true)
            {
                Vector3 randomDirection = enemyView.transform.position + Random.insideUnitSphere * enemyModel.PatrolRange;

                if (NavMesh.SamplePosition(randomDirection, out hit, 1, NavMesh.AllAreas))
                {
                    finalPosition = hit.position;
                    pointFound = true;
                }
            }

            return finalPosition;
        }

        public void GotDamage(BodyArea bodyArea, float damageValue)
        {
            float damageMultiplier;

            switch (bodyArea) 
            {
                case BodyArea.Body:
                    damageMultiplier = enemyModel.BodyDamageMultiplier;
                    break;

                case BodyArea.Head:
                    damageMultiplier = enemyModel.HeadDamageMultiplier;
                    break;

                case BodyArea.Legs:
                    damageMultiplier = enemyModel.LegsDamageMultiplier;
                    break;

                case BodyArea.Eyes:
                    damageMultiplier = enemyModel.EyesDamageMultiplier;
                    break;

                default:
                    damageMultiplier = enemyModel.Zero;
                    break;
            }

            float currentDamage = damageValue * damageMultiplier;
            enemyModel.SetEnemyHealth(enemyModel.CurrentHealth - currentDamage);
            
            CheckIsDead();
        }

        private void CheckIsDead()
        {
            if(enemyModel.CurrentHealth <= enemyModel.Zero)
            {
                enemyStateMachine.EnemyDead();
                enemyView.DestroyObject(enemyModel.DestroyTime);
            }
            else
            {
                enemyStateMachine.GotDamage();
            }
        }
    }
}