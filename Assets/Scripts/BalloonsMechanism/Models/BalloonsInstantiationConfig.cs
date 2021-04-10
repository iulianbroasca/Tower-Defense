using System;
using UnityEngine;

namespace BalloonsMechanism.Models
{
    [Serializable]
    public class BalloonsInstantiationConfig
    {
        [SerializeField] private float infMinTime;
        [SerializeField] private float infMaxTime;
        [SerializeField] private float supMinTime;
        [SerializeField] private float supMaxTime;
        [SerializeField] private float minStep;
        [SerializeField] private float maxStep;
        [SerializeField] private float stepForStep;


        private float infTime;
        private float supTime;
        private float step;

        public void ResetTimeInterval()
        {
            ResetIntervals();
            ResetStep();
        }

        private void ResetIntervals()
        {
            infTime = infMaxTime;
            supTime = supMaxTime;
        }

        private void ResetStep()
        {
            step = maxStep;
        }

        public (float, float) GetNextTimeInterval()
        {
            DecreaseTimeInterval();
            return (infTime, supTime);
        }

        private void DecreaseTimeInterval()
        {
            if (DecreaseInferiorTime())
            {
                DecreaseSuperiorTime();
            }

            DecreaseStep();
        }

        private bool DecreaseInferiorTime()
        {
            if (infTime == infMinTime)
                return true;

            if (infTime - step >= infMinTime)
            {
                infTime -= step;
                return false;
            }
            else
            {
                infTime = infMinTime;
                ResetStep();
                return true;
            }
        }

        private bool DecreaseSuperiorTime()
        {
            if (supTime == supMinTime)
                return true;

            if (supTime - step >= supMinTime)
            {
                supTime -= step;
                return false;
            }
            else
            {
                supTime = supMinTime;
                return true;
            }
        }

        private void DecreaseStep()
        {
            if(step == minStep)
                return;

            if (step - stepForStep >= minStep)
            {
                step -= stepForStep;
            }
        }
    }
}
