using System.Collections.Generic;
using TowersMechanism.Behaviours;
using TowersMechanism.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Towers container", menuName = "Create data containers/Towers container")]
    public class TowersContainer : ScriptableObject
    {
        [SerializeField] private List<TowerItem> towers = new List<TowerItem>();
        [SerializeField] private TowerRangeBehaviour towerRangeBehaviour;
        [SerializeField] private TowerBulletBehaviour towerBulletBehaviour;
        [SerializeField] private TowerAttackBehaviour towerAttackBehaviour;

        public List<TowerItem> GetTowers()
        {
            return towers;
        }

        public TowerRangeBehaviour GetTowerRangeBehaviour()
        {
            return towerRangeBehaviour;
        }

        public TowerAttackBehaviour GetTowerAttackBehaviour()
        {
            return towerAttackBehaviour;
        }

        public TowerBulletBehaviour GetTowerBulletBehaviour()
        {
            return towerBulletBehaviour;
        }

        public TowerItem GetTowerItem(int id)
        {
            return towers.Find(it => it.TowerData.Id == id);
        }
    }
}
