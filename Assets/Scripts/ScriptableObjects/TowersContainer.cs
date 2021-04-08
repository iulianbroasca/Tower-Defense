using System.Collections.Generic;
using TowerMechanism.Behaviours;
using TowerMechanism.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Towers container", menuName = "Create data containers/Towers container")]
    public class TowersContainer : ScriptableObject
    {
        [SerializeField] private List<TowerItem> towers = new List<TowerItem>();
        [SerializeField] private TowerRangeBehaviour towerRangeBehaviour;

        public List<TowerItem> GetTowers()
        {
            return towers;
        }

        public TowerRangeBehaviour GetTowerRangeBehaviour()
        {
            return towerRangeBehaviour;
        }

        public TowerItem GetTower(int id)
        {
            return towers.Find(it => it.Id == id);
        }
    }
}
