using System.Linq;
using Globals;
using TowersMechanism.Behaviours;
using UnityEngine;

namespace TowersMechanism.Components
{
    public class TowerComponent : MonoBehaviour
    {
        private TowerLookAtBehaviour towerLookAtBehaviour;
        private TowerRangeBehaviour towerRangeBehaviour;
        private TowerAttackBehaviour towerAttackBehaviour;

        private void Awake()
        {
            towerLookAtBehaviour = GetComponentInChildren<TowerLookAtBehaviour>();
            if(towerLookAtBehaviour)
                gameObject.AddComponent<TowerLookAtBehaviour>();
        }

        public void SetTowerRangeBehaviour(TowerRangeBehaviour towerRange, float towerDataRange, float bulletLoadingTime)
        {
            towerRangeBehaviour = Instantiate(towerRange, transform);
            towerRangeBehaviour.SetRangeData(Constants.TowerRangePosition, towerDataRange, bulletLoadingTime);
            towerRangeBehaviour.RegisterEventDetectedBalloons(AttackBalloons);
        }

        public void SetTowerAttackBehaviour(TowerAttackBehaviour towerAttack, float bulletSpeed)
        {
            towerAttackBehaviour = Instantiate(towerAttack, transform);
            towerAttackBehaviour.BulletSpeed = bulletSpeed;
        }

        public void SetActiveTowerRange(bool value)
        {
            towerRangeBehaviour.SetActiveRangeGameObject(value);
        }

        public void SetColorOnRange(Color color)
        {
            towerRangeBehaviour.SetColorOnRangeGameObject(color);
        }

        private void AttackBalloons(Collider[] balloons, int numBalloons)
        {
            var position = balloons.First().transform.position;
            towerAttackBehaviour.AttackBalloon(position);
            towerLookAtBehaviour.LookAt(position);
        }
    }
}
