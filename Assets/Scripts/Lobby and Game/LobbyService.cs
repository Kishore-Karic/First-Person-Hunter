using FPHunter.Enum;
using FPHunter.Managers;
using System.Collections.Generic;
using UnityEngine;

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

        private void Awake()
        {
            playerAnimator.runtimeAnimatorController = animatorControllersList[zero];
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

            if(i == (int)ObjectType.DoublePistol)
            {
                GameObject newLeftGun = GameObject.Instantiate(weaponsList[i], playerLeftHand);
                newLeftGun.transform.localPosition = Vector3.zero;
                newLeftGun.transform.localRotation = Quaternion.Euler(localRotation);
            }

            GameObject newRightGun = GameObject.Instantiate(weaponsList[i], playerRightHand);
            newRightGun.transform.localPosition = Vector3.zero;
            newRightGun.transform.localRotation = Quaternion.Euler(localRotation);

            GameManager.Instance.SetWeaponType((ObjectType)i);
            playerAnimator.runtimeAnimatorController = animatorControllersList[++i];
        }
    }
}