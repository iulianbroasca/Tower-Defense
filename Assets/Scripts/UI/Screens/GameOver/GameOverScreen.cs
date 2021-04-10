using Game.Managers;
using UI.BaseScripts;
using UI.Managers;
using UI.Screens.Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GameOver
{
    public class GameOverScreen : BaseScreen
    {
        private Button restartButton;

        private void Awake()
        {
            restartButton = GetComponentInChildren<Button>();
            restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            GameManager.Instance.RestartGame();
            ScreensManager.Instance.SwitchScreen(typeof(GameScreen));
        }
    }
}
