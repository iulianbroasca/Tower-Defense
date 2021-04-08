using UnityEngine;

namespace Utils
{
    public class GenerateRoutePoints : MonoBehaviour
    {
        [ContextMenu("Generate Route Points")]
        private void GeneratePoints()
        {
            var lineRender = GetComponent<LineRenderer>();
            if (!lineRender)
                return;
            var positions = new Vector3[lineRender.positionCount];
            lineRender.GetPositions(positions);

            var point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            foreach (var position in positions)
            {
                Instantiate(point, position, Quaternion.identity);
            }
            DestroyImmediate(point);
        }

        [ContextMenu("Generate Route Cubes")]
        private void GenerateCubes()
        {
            var lineRender = GetComponent<LineRenderer>();
            if (!lineRender)
                return;
            var positions = new Vector3[lineRender.positionCount];
            lineRender.GetPositions(positions);

            var point = GameObject.CreatePrimitive(PrimitiveType.Cube);

            for (int i = 0; i < lineRender.positionCount; i = i + 2)
            {
                Instantiate(point, (positions[i] + positions[i+1])/2f, Quaternion.identity);
            }
            DestroyImmediate(point);
        }
    }
}
