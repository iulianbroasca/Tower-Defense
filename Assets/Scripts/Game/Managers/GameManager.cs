using BalloonsMechanism.Managers;
using Game.Models;
using MonoSingleton;
using UI.Managers;
using UI.Screens.Game;

namespace Game.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private User currentPlayer;
        private GameScreen gameScreen;

        private int level;
        protected override void Awake()
        {
            base.Awake();
            InitializeGame();
        }

        private void Start()
        {
            gameScreen = (GameScreen)ScreensManager.Instance.GetScreen(typeof(GameScreen));
            level = 1;
        }

        public void PlayGame()
        {
            BalloonsManager.Instance.PlayInstantiation(level);
            gameScreen.SetActiveGameModeScreen(false);
        }

        public void LevelCompleted()
        {
            level++;
            gameScreen.SetLevelText(level.ToString());
            gameScreen.SetActiveGameModeScreen(true);
        }

        public float GetCurrentMoney()
        {
            return currentPlayer.Money;
        }

        public int GetCurrentLevel()
        {
            return level;
        }

        public void BuyTower(float price)
        {
            SetCurrentMoney(currentPlayer.Money - price);
        }

        public void IncreaseMoney(float money)
        {
            SetCurrentMoney(currentPlayer.Money + money);
        }

        private void SetCurrentMoney(float price)
        {
            currentPlayer.Money = price;
            gameScreen.SetMoneyText(currentPlayer.Money.ToString());
        }

        private void InitializeGame()
        {
            currentPlayer = new User();
        }
    }
}
