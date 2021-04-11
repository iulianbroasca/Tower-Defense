using Globals;
using UnityEngine;

namespace CameraMechanism
{
    public class MoveCamera : MonoBehaviour
    {
        private bool arrived = true;
        private Vector3 target;

        private void Update()
        {
            if(arrived)
                return;

            transform.position = Vector3.MoveTowards(transform.position, target, Constants.CameraSpeed * Time.deltaTime);

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
