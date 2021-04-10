using System;
using TowersMechanism.Components;
using UnityEngine;

namespace TowersMechanism.Models
{
    [Serializable]
    public class TowerItem
    {
        [SerializeField] private TowerComponent towerComponent;
        [SerializeField] private TowerData towerData;

        public TowerComponent TowerComponent
        {
            get => towerComponent;
            set => towerComponent = value;
        }

        public TowerData TowerData
        {
            get => towerData;
            set => towerData = value;
        }
    }
}
