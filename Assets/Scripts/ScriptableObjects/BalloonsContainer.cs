using System.Collections.Generic;
using BalloonsMechanism.Components;
using BalloonsMechanism.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Balloons container", menuName = "Create data containers/Balloons container")]
    public class BalloonsContainer : ScriptableObject
    {
        [SerializeField] private BalloonsRoute balloonsRoute = new BalloonsRoute();
        [SerializeField] private BalloonComponent balloonComponent;
        [SerializeField, Range(1,10)] private int numberOfBalloonsPerLevel = 1;

        public int NumberOfBalloonsPerLevel => numberOfBalloonsPerLevel;

        public BalloonComponent GetBalloonComponent()
        {
            return balloonComponent;
        }
    }
}
