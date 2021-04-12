using BalloonsMechanism.Components;
using BalloonsMechanism.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Balloons container", menuName = "Create data containers/Balloons container")]
    public class BalloonsContainer : ScriptableObject
    {
        [SerializeField] private BalloonsInstantiationConfig balloonsInstantiationConfig = new BalloonsInstantiationConfig();
        [SerializeField] private BalloonComponent balloonComponent;
        
        [SerializeField, Range(1,4)] [Tooltip("It multiplies with the level of the game.")]
        private int numberOfBalloonsPerLevel = 1;
        [SerializeField, Range(10,100)] private int moneyPerBalloon = 50;

        public int NumberOfBalloonsPerLevel => numberOfBalloonsPerLevel;
        public int MoneyPerBalloon => moneyPerBalloon;

        public BalloonComponent GetBalloonComponent() => balloonComponent;

        public BalloonsInstantiationConfig GetBalloonsRouteConfiguration() => balloonsInstantiationConfig;
    }
}
