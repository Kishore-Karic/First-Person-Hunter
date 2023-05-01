using FPHunter.Managers;
using FPHunter.Player;
using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Enemy
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private EnemyScriptableObjectList enemyScriptableObjectList;
        [SerializeField] private List<Vector3> spawnPoints;
        [SerializeField] private PlayerService playerService;

        private void Start()
        {
            new EnemyController(new EnemyModel(enemyScriptableObjectList.enemyScriptableObjects[GameManager.Instance.GetIndex()]), this, enemyPrefab, spawnPoints[GameManager.Instance.GetIndex()]);
        }

        public Transform GetPlayerObject()
        {
            return playerService.GetPlayerObject();
        }

        public void PlayerDead()
        {
            playerService.PlayerDead();
        }
    }
}