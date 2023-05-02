using FPHunter.Enum;
using UnityEngine;

namespace FPHunter.Enemy 
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private BodyArea bodyArea;
        [SerializeField] private EnemyView enemyView;

        public void Damage(float damageVakue)
        {
            GotDamage(damageVakue);
        }

        private void GotDamage(float damageValue)
        {
            enemyView.GotDamage(bodyArea, damageValue);
        }
    }
}