using FPHunter.Enum;
using FPHunter.GenericSingleton;
using UnityEngine.SceneManagement;

namespace FPHunter.Managers
{
    public class GameManager : GenericSingleton<GameManager>
    {
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
        }

        public void SetIndex(int _value)
        {
            gamePlayIndex = _value;
        }

        public int GetIndex()
        {
            return gamePlayIndex;
        }
    }
}