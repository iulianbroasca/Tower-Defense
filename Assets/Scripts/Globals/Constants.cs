using UnityEngine;

namespace Globals
{
    public static class Constants
    {
        public const int PlayerMoney = 150;
        public static readonly Vector3 TowerRangePosition =  new Vector3(0,0.2f,0);

        public const int MaxBullets = 10;
        public const float BulletLife = 2f;
        public const string MainCanvasTag = "MainCanvas";
        public const string HomeScreenTag = "HomeScreen";

        public const string MapLayer = "Map";
        public const string BalloonLayer = "Balloon";

        public const string MoneyText = "Money: ";
        public const string LevelText = "Level: ";
    }
}
