using FPHunter.Enum;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Weapon
{
    public class WeaponService : MonoBehaviour
    {
        [SerializeField] private List<WeaponView> weaponPrefabs;
        [SerializeField] private WeaponScriptableObjectList weaponScriptableObjectList;
        [SerializeField] private List<GameObject> crosshairList;

        public WeaponView GetWeapon(ObjectType objectType)
        {
            WeaponController weaponController = new WeaponController(new WeaponModel(GetWeaponScriptableObject(objectType)), this, weaponPrefabs[(int)objectType]);
            return weaponController.ReturnWeaponView();
        }

        private WeaponScriptableObject GetWeaponScriptableObject(ObjectType objectType)
        {
            WeaponScriptableObject weaponScriptableObject = null;

            for(int i = 0; i < weaponScriptableObjectList.weaponScriptableObjects.Count; i++)
            {
                if (weaponScriptableObjectList.weaponScriptableObjects[i].ObjectType == objectType)
                {
                    weaponScriptableObject = weaponScriptableObjectList.weaponScriptableObjects[i];
                }
            }

            return weaponScriptableObject;
        }

        public GameObject GetCrosshair(int i)
        {
            return crosshairList[i];
        }
    }
}