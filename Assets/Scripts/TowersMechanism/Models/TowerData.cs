using System;
using UnityEngine;

namespace TowersMechanism.Models
{
    [Serializable]
    public class TowerData
    {
        [SerializeField] private int id;
        [SerializeField] private string name;
        [SerializeField] private float price;
        [SerializeField] private float range;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletLoadingTime;

        public int Id => id;
        public string Name => name;
        public float Price => price;
        public float Range => range;
        public float BulletSpeed => bulletSpeed;
        public float BulletLoadingTime => bulletLoadingTime;
    }
}
