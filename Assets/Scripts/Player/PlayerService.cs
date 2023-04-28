using FPHunter.Player;
using UnityEditor.Animations;
using UnityEngine;

namespace FPHunter.Service
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private PlayerModelData playerModelData;
        [SerializeField] private AnimatorController animator;

        private PlayerController playerController;

        private void Start()
        {
            playerController = new PlayerController(new PlayerModel(playerModelData), playerPrefab, transform, animator);
        }
    }
}