using UI.BaseScripts;
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
            Debug.Log("Restart");
        }
    }
}
