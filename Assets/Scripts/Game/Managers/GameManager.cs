using BalloonsMechanism.Components;
using BalloonsMechanism.Managers;
using Game.Models;
using Globals;
using MonoSingleton;
using TowersMechanism.Managers;
using UI.Managers;
using UI.Screens.Game;

namespace Game.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private User currentPlayer;
        private GameScreen gameScreen;

        private int level;
        
        private void Start()
        {
            InitializeGame();
        }

        public void PlayGame()
        {
            BalloonsManager.Instance.PlayInstantiation(level);
            gameScreen.SetActiveGameModeScreen(false);
        }

        public void LevelCompleted()
        {
            SetLevel(level + 1);
            gameScreen.SetLevelText(level.ToString());
            gameScreen.SetActiveGameModeScreen(true);
        }

        public void RestartGame()
        {
            SetCurrentMoney(Constants.PlayerMoney);
            SetLevel(1);

            TowersManager.Instance.RestartGame();
            BalloonsManager.Instance.RestartGame();
            BalloonComponent.RestartGame();
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

        private void SetLevel(int value)
        {
            level = value;
        }

        private void InitializeGame()
        {
            currentPlayer = new User();
            gameScreen = (GameScreen)ScreensManager.Instance.GetScreen(typeof(GameScreen));
            SetLevel(1);
        }
    }
}
