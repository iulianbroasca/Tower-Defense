using Game.Managers;
using UI.BaseScripts;
using UI.Managers;
using UI.Screens.MapSelection;
using UnityEngine.UI;

namespace UI.Screens.GameOver
{
    public class GameOverScreen : BaseScreen
    {
        private Button restartButton;

        private void Awake()
        {
            restartButton = GetComponentInChildren<Button>();
            restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            GameManager.Instance.RestartGame();
            ScreensManager.Instance.SwitchScreen(typeof(MapSelectionScreen));
        }
    }
}
