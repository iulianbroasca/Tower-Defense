
using System;
using UnityEngine;

namespace TowerMechanism.Models
{
    [Serializable]
    public class TowerData
    {
        [SerializeField] private float price;
        [SerializeField] private float range;

        public float Price => price;
        public float Range => range;
    }
}
