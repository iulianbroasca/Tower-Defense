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
            if(towerLookAtBehaviour == null)
                towerLookAtBehaviour = gameObject.AddComponent<TowerLookAtBehaviour>();
        }

        public void SetTowerRangeBehaviour(TowerRangeBehaviour towerRange, float towerDataRange, float bulletLoadingTime)
        {
            towerRangeBehaviour = Instantiate(towerRange, transform);
            towerRangeBehaviour.SetRangeData(Constants.TowerRangePosition, transform.localScale, towerDataRange, bulletLoadingTime);
            towerRangeBehaviour.RegisterEventDetectedBalloons(AttackBalloons);
        }

        public void SetTowerAttackBehaviour(TowerAttackBehaviour towerAttack, float bulletSpeed)
        {
            towerAttackBehaviour = Instantiate(towerAttack, transform);
            towerAttackBehaviour.BulletSpeed = bulletSpeed;
            towerAttackBehaviour.SetPosition(transform.Find(Constants.PointAttack).localPosition);
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
            towerAttackBehaviour.AttackBalloon(balloons.First().transform.position);
            towerLookAtBehaviour.LookAt(balloons.First().transform);
        }
    }
}
