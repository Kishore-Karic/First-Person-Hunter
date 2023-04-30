using UnityEngine;

namespace FPHunter.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletService bulletService;
        private BulletView bulletView;

        public BulletController(BulletModel _bulletModel, BulletService _bulletService, BulletView _bulletView, Transform spawnPoint, Quaternion spwanRotation)
        {
            bulletModel = _bulletModel;
            bulletService = _bulletService;
            bulletView = GameObject.Instantiate(_bulletView);

            bulletView.SetBulletController(this);
            bulletView.transform.position = spawnPoint.position;
            bulletView.transform.rotation = spwanRotation;

            FireBullet();
        }

        private void FireBullet()
        {
            Vector3 bulletDirection = bulletView.transform.forward;
            bulletView.RigidBody.AddForce(bulletDirection * bulletModel.MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        public float GetDestroyTime()
        {
            return bulletModel.DestroyTime;
        }
    }
}