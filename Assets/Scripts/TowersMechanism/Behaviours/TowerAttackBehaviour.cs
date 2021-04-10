using ObjectPool;
using TowersMechanism.Managers;
using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerAttackBehaviour : MonoBehaviour
    {
        public float Damage { get; set; }
        public float BulletSpeed { get; set; }

        public void AttackBalloon(Vector3 position)
        {
            TowersManager.Instance.GetBulletsPool().GetObjectFromPool().Attack(transform.position,position, Damage, BulletSpeed);
        }
    }
}
