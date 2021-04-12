using Map.Components;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [RequireComponent(typeof(MapComponent))]
    public class GenerateMap : MonoBehaviour
    {
        [SerializeField] private int size;

        [SerializeField] private GameObject tile;
        [SerializeField] private GameObject tileMargin;
        [SerializeField] private GameObject changeWith;

        [ContextMenu("Generate Map")]
        private void Generate()
        {
            if(!gameObject.GetComponent<MapComponent>())
                return;

            var tilesGameObject = new GameObject("Tiles");
            var grass = new GameObject("Grass");
            var margins = new GameObject("Margins");
            tilesGameObject.transform.parent = transform;
            grass.transform.parent = tilesGameObject.transform;
            margins.transform.parent = tilesGameObject.transform;

            var current = Vector3.zero;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    GameObject obj;
                    if (i == size - 1 || j == size - 1 || i == 0 || j == 0)
                    {
                        obj = Instantiate(tileMargin, margins.transform);
                    }
                    else
                    {
                        obj = Instantiate(tile, grass.transform);
                    }
                    obj.transform.localPosition = new Vector3(j, 0, -i);
                }
            }
        }

        [ContextMenu("Change")]
        private void Change()
        {
            var gameObjects = Selection.gameObjects;
            var tilesGameObject = transform.Find("Tiles");
            foreach (var go in gameObjects)
            {
                var obj = Instantiate(changeWith, tilesGameObject.transform);
                obj.transform.localPosition = go.transform.localPosition;
                DestroyImmediate(go);
            }
        }

        [ContextMenu("DeleteColliders")]
        private void DeleteColliders()
        {
            var gameObjects = Selection.gameObjects;
            foreach (var go in gameObjects)
            {
                var colliders = go.GetComponentsInChildren<BoxCollider>();
                foreach (var collider in colliders)
                {
                    DestroyImmediate(collider);
                }
            }
        }
    }
}
