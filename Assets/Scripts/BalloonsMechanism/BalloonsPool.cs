using System;
using System.Collections.Generic;
using BalloonsMechanism.Components;
using ObjectPool.BaseScripts;

namespace BalloonsMechanism
{
    public class BalloonsPool : BaseObjectPool<BalloonComponent>
    {
        private readonly List<BalloonComponent> balloonsInScene = new List<BalloonComponent>();

        private int numberBalloonsInScene;
        private int numberBalloonsOnLevel;
        private Action balloonsDestroyed;

        public override BalloonComponent GetObjectFromPool()
        {
            numberBalloonsInScene++;
            var balloon = base.GetObjectFromPool();
            balloonsInScene.Add(balloon);
            return balloon;
        }

        public override void AddObjectToPool(BalloonComponent balloonComponent)
        {
            balloonsInScene.Remove(balloonComponent);
            base.AddObjectToPool(balloonComponent);
            CheckSceneContainsBalloons();
        }

        public void ClearBalloonsFromScene()
        {
            foreach (var balloon in balloonsInScene)
            {
                base.AddObjectToPool(balloon);
            }
            balloonsInScene.Clear();
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
