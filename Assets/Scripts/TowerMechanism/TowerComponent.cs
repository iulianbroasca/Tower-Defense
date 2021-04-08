using Globals;
using TowerMechanism.Behaviours;
using UnityEngine;

namespace TowerMechanism
{
    public class TowerComponent : MonoBehaviour
    {
        private TowerRangeBehaviour towerRangeBehaviour;

        public void SetTowerRangeBehaviour(TowerRangeBehaviour towerRange, float range)
        {
            towerRangeBehaviour = Instantiate(towerRange, transform);
            towerRangeBehaviour.SetRange(Constants.TowerRangePosition, range);
        }

        public void SetActiveTowerRange(bool value)
        {
            towerRangeBehaviour.gameObject.SetActive(value);
        }
    }
}
