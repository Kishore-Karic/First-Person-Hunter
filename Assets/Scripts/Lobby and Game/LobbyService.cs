using FPHunter.Enum;
using FPHunter.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPHunter.Service
{
    public class LobbyService : MonoBehaviour
    {
        [SerializeField] private GameObject playerObject;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private List<RuntimeAnimatorController> animatorControllersList;
        [SerializeField] private List<GameObject> weaponsList;
        [SerializeField] private Transform playerRightHand;
        [SerializeField] private Transform playerLeftHand;
        [SerializeField] private Vector3 localRotation;
        [SerializeField] private int zero;
        [SerializeField] private List<GameObject> enemySlides;
        [SerializeField] private int enemySlidesMinCount;
        [SerializeField] private int enemySlidesMaxCount;
        [SerializeField] private Button previosButton;
        [SerializeField] private Button nextsButton;
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private float actualTime;

        private int enemySlidesCurrentCount;
        
        private void Awake()
        {
            previosButton.onClick.AddListener(ShowPreviousSlide);
            nextsButton.onClick.AddListener(ShowNextSlide);
            if (startButton.interactable)
            {
                startButton.onClick.AddListener(GameManager.Instance.StartGame);
            }
            exitButton.onClick.AddListener(GameManager.Instance.ExitGame);
        }

        private void Start()
        {
            Time.timeScale = actualTime;
            startButton.interactable = false;
            playerAnimator.runtimeAnimatorController = animatorControllersList[zero];
            enemySlidesCurrentCount = enemySlidesMinCount;
            SoundManager.Instance.StopMusic(Sounds.GameTheme);
            SoundManager.Instance.PlayMusic(Sounds.LobbyTheme);
        }

        private void ShowPreviousSlide()
        {
            if(enemySlidesCurrentCount != enemySlidesMinCount)
            {
                enemySlides[enemySlidesCurrentCount].SetActive(false);
                enemySlidesCurrentCount--;
                enemySlides[enemySlidesCurrentCount].SetActive(true);
            }

            GameManager.Instance.SetIndex(enemySlidesCurrentCount);
        }

        private void ShowNextSlide()
        {
            if (enemySlidesCurrentCount != enemySlidesMaxCount)
            {
                enemySlides[enemySlidesCurrentCount].SetActive(false);
                enemySlidesCurrentCount++;
                enemySlides[enemySlidesCurrentCount].SetActive(true);
            }

            GameManager.Instance.SetIndex(enemySlidesCurrentCount);
        }

        public void ButtonClick(int i)
        {
            ShowWeapon(i);
        }

        private void ShowWeapon(int i)
        {
            
            if(playerRightHand.childCount > zero)
            {
                Destroy(playerRightHand.GetChild(zero).gameObject);
            }
            if(playerLeftHand.childCount > zero)
            {
                Destroy(playerLeftHand.GetChild(zero).gameObject);
            }

            if (i == (int)WeaponType.DoublePistol)
            {
                GameObject newLeftGun = Instantiate(weaponsList[i], playerLeftHand);
                newLeftGun.transform.localPosition = Vector3.zero;
                newLeftGun.transform.localRotation = Quaternion.Euler(localRotation);
            }

            GameObject newRightGun = Instantiate(weaponsList[i], playerRightHand);
            newRightGun.transform.localPosition = Vector3.zero;
            newRightGun.transform.localRotation = Quaternion.Euler(localRotation);

            GameManager.Instance.SetWeaponType((WeaponType)i);
            startButton.interactable = true;
            playerAnimator.runtimeAnimatorController = animatorControllersList[++i];
        }
    }
}