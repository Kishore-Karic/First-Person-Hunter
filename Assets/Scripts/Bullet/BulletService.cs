using FPHunter.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace FPHunter.Bullet
{
    public class BulletService : MonoBehaviour
    {
        [SerializeField] private List<BulletView> bulletPrefabs;
        [SerializeField] private BulletScriptableObjectList bulletScriptableObjectList;

        public void SpawnBullet(BulletType bulletType, Transform spawnPoint, Quaternion spawnRotation)
        {
            new BulletController(new BulletModel(GetBulletScriptableObject(bulletType)), this, bulletPrefabs[(int)bulletType], spawnPoint, spawnRotation);
        }

        private BulletScriptableObject GetBulletScriptableObject(BulletType bulletType)
        {
            BulletScriptableObject bulletScriptableObject = null;

            for(int i = 0; i < bulletScriptableObjectList.bulletScriptableObjects.Count; i++)
            {
                if (bulletScriptableObjectList.bulletScriptableObjects[i].BulletType == bulletType)
                {
                    bulletScriptableObject = bulletScriptableObjectList.bulletScriptableObjects[i];
                    break;
                }
            }

            return bulletScriptableObject;
        }
    }
}