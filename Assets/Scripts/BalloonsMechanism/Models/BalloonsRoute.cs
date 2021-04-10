using System;
using UnityEngine;

namespace BalloonsMechanism.Models
{
    [Serializable]
    public class BalloonsRoute
    {
        [SerializeField] private float minLeft;
        [SerializeField] private float maxLeft;
        [SerializeField] private float minRight;
        [SerializeField] private float maxRight;
    }
}
