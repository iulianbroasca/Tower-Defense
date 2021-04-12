using System.Linq;
using BalloonsMechanism.Managers;
using Game.Managers;
using UI.Managers;
using UI.Screens.GameOver;
using UnityEngine;

namespace BalloonsMechanism.Components
{ 
    public class BalloonComponent : MonoBehaviour
    {
        private static Vector3[] positions;
        private static bool completed;
        private static Vector2 speedInterval;
        private int currentIndexPosition;

        private bool touched;
        private float randomSpeed;

        private void OnEnable()
        {
            InitializeBalloon();
        }

        private void Update()
        {
            if (completed)
                return;

            transform.position = Vector3.MoveTowards(transform.position,
                positions[currentIndexPosition],
                GetRandomSpeed() * Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (completed || !(Vector3.Distance(transform.position, positions[currentIndexPosition]) < 0.1f)) 
                return;

            currentIndexPosition++;
            if (currentIndexPosition == positions.Length)
                CompleteRoute();
        }

        public void BalloonTouched()
        {
            if(touched)
                return;

            touched = true;
            BalloonsManager.Instance.BalloonTouched(this);
        }

        public static void SetSpeed(Vector2 speed)
        {
            speedInterval = speed;
        }

        public static void RestartGame()
        {
            completed = false;
            positions = null;
        }

        private float GetRandomSpeed()
        {
            if (randomSpeed != 0) 
                return randomSpeed;

            var level = GameManager.Instance.GetCurrentLevel();
            randomSpeed = Random.Range(speedInterval.x + level / 15f, speedInterval.y + level / 5f);
            return randomSpeed;
        }

        public static void SetRoutePositions(Vector3[] routePositions)
        {
            if (positions == null)
            {
                positions = routePositions;
            }
        }

        private void CompleteRoute()
        {
            completed = true;
            ScreensManager.Instance.SwitchScreen(typeof(GameOverScreen));
        }

        private void InitializeBalloon()
        {
            transform.localPosition = positions.First();
            currentIndexPosition = 0;
            randomSpeed = 0;
            touched = false;
        }

        private void OnDisable()
        {
            transform.localPosition = positions.First();
        }
    }
}
