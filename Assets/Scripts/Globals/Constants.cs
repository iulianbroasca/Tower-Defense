using UnityEngine;

namespace Globals
{
    public static class Constants
    {
        public const int PlayerMoney = 10000;
        public static readonly Vector3 TowerRangePosition =  new Vector3(0,0.2f,0);

        public static class Tags
        {
            public const string MainCanvas = "MainCanvas";
            public const string HomeScreen = "HomeScreen";
        }

        public static class Layers
        {
            public const string Map = "Map";
            public const string Route = "Route";
        }
    }
}
