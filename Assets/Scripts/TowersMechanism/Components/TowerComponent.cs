using System.Linq;
using Globals;
using TowersMechanism.Behaviours;
using UnityEngine;

namespace TowersMechanism.Components
{
    public class TowerComponent : MonoBehaviour
    {
        private TowerRangeBehaviour towerRangeBehaviour;
        private TowerAttackBehaviour towerAttackBehaviour;

        public void SetTowerRangeBehaviour(TowerRangeBehaviour towerRange, float towerDataRange, float bulletLoadingTime)
        {
            towerRangeBehaviour = Instantiate(towerRange, transform);
            towerRangeBehaviour.SetRangeData(Constants.TowerRangePosition, towerDataRange, bulletLoadingTime);
            towerRangeBehaviour.RegisterEventDetectedBalloons(AttackBalloons);
        }

        public void SetTowerAttackBehaviour(TowerAttackBehaviour towerAttack, float damage, float bulletSpeed)
        {
            towerAttackBehaviour = Instantiate(towerAttack, transform);
            towerAttackBehaviour.Damage = damage;
            towerAttackBehaviour.BulletSpeed = bulletSpeed;
        }

        public void SetActiveTowerRange(bool value)
        {
            towerRangeBehaviour.SetActiveRangeGameObject(value);
        }

        private void AttackBalloons(Collider[] balloons, int numBalloons)
        {
            towerAttackBehaviour.AttackBalloon(balloons.First().transform.position);
        }
    }
}
