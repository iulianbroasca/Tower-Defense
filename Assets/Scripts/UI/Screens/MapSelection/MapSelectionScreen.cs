using CameraMechanism;
using Map.Managers;
using UI.BaseScripts;
using UI.Managers;
using UI.Screens.Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.MapSelection
{
    public class MapSelectionScreen : BaseScreen
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextMapButton;

        private MoveCamera moveCamera;
        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            nextMapButton.onClick.AddListener(NextMap);
            moveCamera = Camera.main.GetComponent<MoveCamera>();
        }

        private void StartGame()
        {
            ScreensManager.Instance.SwitchScreen(typeof(GameScreen));
        }

        private void NextMap()
        {
            moveCamera.MoveCameraToTarget(MapsManager.Instance.NextMap().GetCameraPoint());
        }
    }
}
