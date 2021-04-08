using UI.BaseScripts;
using UI.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
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
            ScreenManager.Instance.SwitchScreen(typeof(TowersConfigurationScreen));
        }
    }
}
