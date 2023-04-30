using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Bullet
{
    [CreateAssetMenu(fileName = "BulletList", menuName = "ScriptableObjects/New BulletList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public List<BulletScriptableObject> bulletScriptableObjects;
    }
}