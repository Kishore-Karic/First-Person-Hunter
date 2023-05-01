using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Enemy 
{
    [CreateAssetMenu(fileName = "BearList", menuName = "ScriptableObjects/New BearList")]
    public class EnemyScriptableObjectList : ScriptableObject
    {
        public List<EnemyScriptableObject> enemyScriptableObjects;
    }
}