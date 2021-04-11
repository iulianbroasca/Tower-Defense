using UnityEngine;

namespace CameraMechanism
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] private float speed;

        private bool arrived = true;
        private Vector3 target;

        private void Update()
        {
            if(arrived)
                return;

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                arrived = true;
            }
        }

        public void MoveCameraToTarget(Vector3 targetPosition)
        {
            target = targetPosition;
            arrived = false;
        }
    }
}
