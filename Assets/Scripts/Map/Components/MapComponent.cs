using UnityEngine;

namespace Map.Components
{
    public class MapComponent : MonoBehaviour
    {
        private Vector3[] routePositions;

        private void Awake()
        {
            InitializeRoutePositions();
        }

        public Vector3[] GetRoutePositions()
        {
            return routePositions;
        }

        private void InitializeRoutePositions()
        {
            var lineRenderer = GetComponentInChildren<LineRenderer>();
            routePositions = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(routePositions);
        }
    }
}
