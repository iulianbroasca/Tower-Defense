using UI.Managers;
using UI.Screens;
using UnityEngine;

namespace BalloonsMechanism
{
    public class BalloonBehaviour : MonoBehaviour
    {
        private int currentIndexPosition;

        private Vector3[] positions;
        private static bool completed;
        public LineRenderer lineRenderer;
        private void Start()
        {
            if (!lineRenderer)
                return;
            positions = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(positions);
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

            if (Vector3.Distance(transform.position, positions[currentIndexPosition]) < 0.1f)
            {
                currentIndexPosition++;
                if (currentIndexPosition == positions.Length)
                    CompleteRoute();
            }
        }

        private void CompleteRoute()
        {
            completed = true;
            ScreenManager.Instance.SwitchScreen(typeof(GameOverScreen));
        }
    }
}
