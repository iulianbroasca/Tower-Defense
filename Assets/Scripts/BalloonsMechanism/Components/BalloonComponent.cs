using System.Linq;
using BalloonsMechanism.Managers;
using Map.Managers;
using UI.Managers;
using UI.Screens.GameOver;
using UnityEngine;

namespace BalloonsMechanism.Components
{ 
    public class BalloonComponent : MonoBehaviour
    {
        private static Vector3[] positions;
        private static bool completed;

        private int currentIndexPosition;

        private bool touched;

        private void OnEnable()
        {
            SetRoutePositions(MapsManager.Instance.GetCurrentMap().GetRoutePositions());
            transform.localPosition = positions.First();
            currentIndexPosition = 0;
            touched = false;
        }

        private void Update()
        {
            if (completed)
                return;

            transform.position = Vector3.MoveTowards(transform.position,
                positions[currentIndexPosition],
                10 * Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (completed)
                return;

            if (!(Vector3.Distance(transform.position, positions[currentIndexPosition]) < 0.1f)) 
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

        public static void RestartGame()
        {
            completed = false;
        }

        private void SetRoutePositions(Vector3[] routePositions)
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

        private void OnDisable()
        {
            transform.localPosition = positions.First();
        }
    }
}
