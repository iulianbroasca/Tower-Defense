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
            towersConfiguration = GetComponentInChildren<TowersConfiguration>();
            gameMode = GetComponentInChildren<GameMode>();
            SetMoneyText(GameManager.Instance.GetCurrentMoney().ToString());
            SetLevelText(GameManager.Instance.GetCurrentLevel().ToString());
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
    }
}
