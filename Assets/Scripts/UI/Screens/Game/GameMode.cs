using Game.Managers;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Game
{
    public class GameMode : MonoBehaviour
    {
        [SerializeField] private Text moneyTextComponent;
        [SerializeField] private Text levelTextComponent;
        private Button playButton;

        private void Start()
        {
            playButton = GetComponentInChildren<Button>();
            playButton.onClick.AddListener(() =>
            {
                GameManager.Instance.PlayGame();
                SetInteractableOnPlayButton(false);
            });
        }

        public void SetMoneyText(string money)
        {
            moneyTextComponent.text = Constants.MoneyText + money;
        }

        public void SetLevelText(string level)
        {
            levelTextComponent.text = Constants.LevelText + level;
        }

        public void SetInteractableOnPlayButton(bool value)
        {
            playButton.interactable = value;
        }
    }
}
