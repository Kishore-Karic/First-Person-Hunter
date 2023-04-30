using UnityEngine;

namespace FPHunter.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }

        private BulletController bulletController;
        private float currentTime;

        private void Update()
        {
            currentTime += Time.deltaTime;
            if(currentTime > bulletController.GetDestroyTime())
            {
                DestroyObject();
            }
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void OnColliderEnter(Collider other)
        {
            DestroyObject();
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}