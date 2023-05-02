using FPHunter.Enum;
using FPHunter.GenericSingleton;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPHunter.Managers
{
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField] private GameObject gameFailedLayer;
        [SerializeField] private GameObject gameWonLayer;
        [SerializeField] private float returnTime;

        private ObjectType objectType;
        private int gamePlayIndex;

        public void SetWeaponType(ObjectType _objectType)
        {
            objectType = _objectType;
        }

        public ObjectType GetWeaponType()
        {
            return objectType;
        }

        public void StartGame()
        {
            int gameScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(++gameScene);
            gameFailedLayer.SetActive(false);
            gameWonLayer.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void SetIndex(int _value)
        {
            gamePlayIndex = _value;
        }

        public int GetIndex()
        {
            return gamePlayIndex;
        }

        public void PlayerDead()
        {
            gameFailedLayer.SetActive(true);
            StartCoroutine(ReturnToLobby());
        }

        public void PlayerWon()
        {
            gameWonLayer.SetActive(true);
            StartCoroutine(ReturnToLobby());
        }

        IEnumerator ReturnToLobby()
        {
            yield return new WaitForSeconds(returnTime);

            int gameScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(--gameScene);
            gameFailedLayer.SetActive(false);
            gameWonLayer.SetActive(false);
        }
    }
}