using System;
using BalloonsMechanism.Components;
using ObjectPool.BaseScripts;

namespace BalloonsMechanism
{
    public class BalloonsPool : BaseObjectPool<BalloonComponent>
    {
        private int numberBalloonsInScene;
        private int numberBalloonsOnLevel;
        private Action balloonsDestroyed;

        public override BalloonComponent GetObjectFromPool()
        {
            numberBalloonsInScene++;
            return base.GetObjectFromPool();
        }

        public override void AddObjectToPool(BalloonComponent component)
        {
            base.AddObjectToPool(component);
            CheckSceneContainsBalloons();
        }

        public void RegisterBalloonsDestroyed(Action action)
        {
            balloonsDestroyed = action;
        }

        public void PreparePoolForLevel(int numberOfBalloonsPerLevel)
        {
            numberBalloonsInScene = 0;
            numberBalloonsOnLevel = numberOfBalloonsPerLevel;
        }

        private void CheckSceneContainsBalloons()
        {
            if (numberBalloonsInScene == numberBalloonsOnLevel)
            {
                balloonsDestroyed.Invoke();
            }
        }

    }
}
