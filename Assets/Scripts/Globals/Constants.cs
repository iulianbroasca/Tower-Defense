using UnityEngine;

namespace Globals
{
    public static class Constants
    {
        public static readonly Vector3 TowerRangePosition =  new Vector3(0,0.01f,0);
        public static readonly Color ColorRangeOnMap = new Color(0, 0, 0, 0.375f);
        public static readonly Color ColorRangeOutsideMap = new Color(1,0,0, 0.375f);
        public const int PlayerMoney = 150;

        public const float CameraSpeed = 16;

        public const int MaxBullets = 10;
        public const float BulletLife = 2f;
        public const string MainCanvasTag = "MainCanvas";
        public const string HomeScreenTag = "HomeScreen";
        public const string MapsTag = "Maps";

        public const string MapLayer = "Map";
        public const string OutsideMapLayer = "OutsideMap";
        public const string BalloonLayer = "Balloon";

        public const string MoneyText = "Money: ";
        public const string LevelText = "Level: ";

        public const string PointAttack = "PointAttack";
    }
}
