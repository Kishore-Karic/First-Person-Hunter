using FPHunter.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponService : MonoBehaviour
    {
        [SerializeField] private List<WeaponView> weaponPrefabs;
        [SerializeField] private WeaponScriptableObjectList weaponScriptableObjectList;
        [SerializeField] private List<GameObject> crosshairList;
        public bool IsCrosshairCreated { get; private set; }

        public WeaponView GetWeapon(WeaponType weaponType)
        {   
            WeaponController weaponController = new WeaponController(new WeaponModel(GetWeaponScriptableObject(weaponType)), this, weaponPrefabs[(int)weaponType]);
            return weaponController.ReturnWeaponView();
        }

        private WeaponScriptableObject GetWeaponScriptableObject(WeaponType weaponType)
        {
            WeaponScriptableObject weaponScriptableObject = null;

            for(int i = 0; i < weaponScriptableObjectList.weaponScriptableObjects.Count; i++)
            {
                if (weaponScriptableObjectList.weaponScriptableObjects[i].WeaponType == weaponType)
                {
                    weaponScriptableObject = weaponScriptableObjectList.weaponScriptableObjects[i];
                    break;
                }
            }

            return weaponScriptableObject;
        }

        public void SetIsCrosshairCreated(bool _value)
        {
            IsCrosshairCreated = _value;
        }

        public GameObject GetCrosshair(int i)
        {
            return crosshairList[i];
        }
    }
}