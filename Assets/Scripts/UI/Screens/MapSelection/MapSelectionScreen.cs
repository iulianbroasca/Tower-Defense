using UI.BaseScripts;
using UI.Managers;
using UI.Screens.Game;
using UnityEngine.UI;

namespace UI.Screens.MapSelection
{
    public class MapSelectionScreen : BaseScreen
    {
        private Button startButton;

        private void Awake()
        {
            startButton = GetComponentInChildren<Button>();
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            ScreensManager.Instance.SwitchScreen(typeof(GameScreen));
        }
    }
}
