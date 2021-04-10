using Map.Components;
using MonoSingleton;
using UnityEngine;

namespace Map.Managers
{
    public class MapsManager : MonoSingleton<MapsManager>
    {
        [SerializeField] private MapComponent currentMap;

        public MapComponent GetCurrentMap()
        {
            return currentMap;
        }
    }
}
