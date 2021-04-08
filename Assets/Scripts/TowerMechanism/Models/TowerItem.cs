using System;
using TowerMechanism.Behaviours;
using UnityEngine;

namespace TowerMechanism.Models
{
    [Serializable]
    public class TowerItem
    {
        [SerializeField] private int id;
        [SerializeField] private string name;
        [SerializeField] private TowerComponent towerComponent;
        [SerializeField] private TowerData towerData;

        public int Id => id;

        public string Name => name;

        public TowerComponent TowerComponent => towerComponent;

        public TowerData TowerData => towerData;
    }
}
