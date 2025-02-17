using Game.Managers;
using UI.BaseScripts;

namespace UI.Screens.Game
{
    public class GameScreen : BaseScreen
    {
        private TowersConfiguration towersConfiguration;
        private GameMode gameMode;

        public override void EnableScreen()
        {
            base.EnableScreen();
            Initialize();
        }

        public override void DisableScreen()
        {
            base.DisableScreen();
            SetActiveGameModeScreen(true);
        }

        public void SetMoneyText(string money)
        {
            gameMode.SetMoneyText(money);
        }

        public void SetLevelText(string level)
        {
            gameMode.SetLevelText(level);
        }

        public void SetActiveGameModeScreen(bool value)
        {
            gameMode.SetInteractableOnPlayButton(value);
            towersConfiguration.gameObject.SetActive(value);
        }

        private void Initialize()
        {
            towersConfiguration = GetComponentInChildren<TowersConfiguration>();
            gameMode = GetComponentInChildren<GameMode>();
            SetMoneyText(GameManager.Instance.GetCurrentMoney().ToString());
            SetLevelText(GameManager.Instance.GetCurrentLevel().ToString());
            gameMode.SetInteractableOnPlayButton(false);
        }
    }
}
