using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Weapon
{
    [CreateAssetMenu(fileName = "WeaponList", menuName = "ScriptableObjects/New WeaponList")]
    public class WeaponScriptableObjectList : ScriptableObject
    {
        public List<WeaponScriptableObject> weaponScriptableObjects;
    }
}