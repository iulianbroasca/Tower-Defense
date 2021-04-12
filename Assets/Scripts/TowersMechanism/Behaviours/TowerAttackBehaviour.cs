using TowersMechanism.Managers;
using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerAttackBehaviour : MonoBehaviour
    {
        public float BulletSpeed { private get; set; }

        public void SetPosition(Vector3 position)
        {
            transform.localPosition = position;
        }

        public void AttackBalloon(Vector3 position)
        {
            TowersManager.Instance.GetBulletsPool().GetObjectFromPool().Attack(transform.position,position, BulletSpeed);
        }
    }
}
