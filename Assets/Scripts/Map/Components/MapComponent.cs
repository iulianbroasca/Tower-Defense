using UnityEngine;

namespace Map.Components
{
    public class MapComponent : MonoBehaviour
    {
        [SerializeField] private Vector3[] routePositions;
        [SerializeField] private GameObject cameraPoint;

        public Vector3[] GetRoutePositions()
        {
            return ReturnGlobalPoints(routePositions);
        }

        public Vector3 GetCameraPoint()
        {
            return cameraPoint.transform.position;
        }

        private Vector3[] ReturnGlobalPoints(Vector3[] positions)
        {
            var localPositions = new Vector3[positions.Length];

            for (var i = 0; i < positions.Length; i++)
            {
                localPositions[i] = transform.TransformPoint(positions[i]);
            }

            return localPositions;
        }
    }
}
