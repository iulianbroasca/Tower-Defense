using System.Collections;
using BalloonsMechanism.Components;
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

        private bool gameStarted;
        private int numberBalloonsRemained;
        protected override void Awake()
        {
            base.Awake();
            balloonsPool = gameObject.AddComponent<BalloonsPool>();
            balloonsPool.RegisterComponent(balloonsContainer.GetBalloonComponent());
            balloonsPool.RegisterBalloonsDestroyed(BalloonsDestroyed);
        }

        private void Start()
        {
            StartCoroutine(InstantiateBalloons());
        }

        public void BalloonTouched(BalloonComponent component)
        {
            balloonsPool.AddObjectToPool(component);
        }

        public void PlayInstantiation(int level)
        {
            numberBalloonsRemained = level * balloonsContainer.NumberOfBalloonsPerLevel;
            balloonsPool.PreparePoolForLevel(numberBalloonsRemained);
            gameStarted = true;
        }

        public void StopInstantiation()
        {
            gameStarted = false;
        }

        private IEnumerator InstantiateBalloons()
        {
            while (true)
            {
                yield return new WaitUntil(() => gameStarted);

                yield return new WaitForSeconds(Random.Range(0, 3.0f));

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

    }
}