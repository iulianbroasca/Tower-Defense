using System.Collections.Generic;
using System.Linq;
using Globals;
using Map.Components;
using MonoSingleton;
using UnityEngine;

namespace Map.Managers
{
    public class MapsManager : MonoSingleton<MapsManager>
    {
        private MapComponent currentMap;
        private List<MapComponent> mapComponents;

        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        public MapComponent GetCurrentMap()
        {
            return currentMap;
        }

        public MapComponent NextMap()
        {
            var index = mapComponents.IndexOf(currentMap);
            index++;
            if (index == mapComponents.Count)
                index = 0;

            currentMap = mapComponents[index];
            return currentMap;
        }

        private void Initialize()
        {
            mapComponents = GameObject.FindGameObjectWithTag(Constants.MapsTag).GetComponentsInChildren<MapComponent>().ToList();
            currentMap = mapComponents.First();
        }
    }
}
