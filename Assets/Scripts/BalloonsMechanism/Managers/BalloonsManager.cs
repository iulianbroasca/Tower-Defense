using System.Collections;
using BalloonsMechanism.Components;
using BalloonsMechanism.Models;
using Game.Managers;
using MonoSingleton;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BalloonsMechanism.Managers
{
    public class BalloonsManager : MonoSingleton<BalloonsManager>
    {
        [SerializeField] private BalloonsContainer balloonsContainer;
        private BalloonsPool balloonsPool;
        private BalloonsInstantiationConfig balloonsInstantiationConfig;

        private bool gameStarted;
        private int numberBalloonsRemained;
        private (float inferior, float superior) timeInterval;

        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        private void Start()
        {
            StartCoroutine(InstantiateBalloons());
        }

        public void BalloonTouched(BalloonComponent component)
        {
            GameManager.Instance.IncreaseMoney(balloonsContainer.MoneyPerBalloon);
            balloonsPool.AddObjectToPool(component);
        }

        public void PlayInstantiation(int level)
        {
            numberBalloonsRemained = level * balloonsContainer.NumberOfBalloonsPerLevel;
            balloonsPool.PreparePoolForLevel(numberBalloonsRemained);
            timeInterval = balloonsInstantiationConfig.GetNextTimeInterval();
            gameStarted = true;
        }

        public void StopInstantiation()
        {
            gameStarted = false;
        }

        public void RestartGame()
        {
            balloonsInstantiationConfig.ResetTimeInterval();
            balloonsPool.ClearBalloonsFromScene();
        }

        private IEnumerator InstantiateBalloons()
        {
            while (true)
            {
                yield return new WaitUntil(() => gameStarted);
                yield return new WaitForSeconds(Random.Range(timeInterval.inferior, timeInterval.superior));

                balloonsPool.GetObjectFromPool();
                DecreaseNumberBalloons();
            }
        }

        private void DecreaseNumberBalloons()
        {
            numberBalloonsRemained--;
            if (numberBalloonsRemained == 0)
            {
                StopInstantiation();
            }
        }

        private void BalloonsDestroyed()
        {
            GameManager.Instance.LevelCompleted();
        }

        private void Initialize()
        {
            balloonsPool = gameObject.AddComponent<BalloonsPool>();
            balloonsPool.RegisterComponent(balloonsContainer.GetBalloonComponent());
            balloonsPool.RegisterBalloonsDestroyed(BalloonsDestroyed);

            balloonsInstantiationConfig = balloonsContainer.GetBalloonsRouteConfiguration();
            balloonsInstantiationConfig.ResetTimeInterval();
            BalloonComponent.SetSpeed(balloonsInstantiationConfig.GetSpeedInterval());
        }

    }
}