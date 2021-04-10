using System.Collections.Generic;
using Game;
using Game.Managers;
using TowersMechanism.Managers;
using TowersMechanism.Models;
using UI.Buttons;
using UnityEngine;

namespace UI.Screens.Game
{
    public class TowersConfiguration : MonoBehaviour
    {
        [SerializeField] private RectTransform contentPanel;
        [SerializeField] private TowerButton towerButton;

        private TowersManager towersManager;
        private GameManager gameManager;
        private List<TowerButton> towerButtons = new List<TowerButton>();

        private void Awake()
        {
            towersManager = TowersManager.Instance;
            gameManager = GameManager.Instance;
            PopulateContentPanel(towersManager.GetTowersContainer().GetTowers());
            RefreshButtonsAvailability();
        }

        private void OnEnable()
        {
            RefreshButtonsAvailability();
        }

        private void PopulateContentPanel(List<TowerItem> towers)
        {
            foreach (var tower in towers)
            {
                InstantiateButton(tower);
            }
        }

        private void InstantiateButton(TowerItem towerItem)
        {
            var button = Instantiate(towerButton, contentPanel);
            button.transform.SetAsLastSibling();
            button.InitializationButton(towerItem.TowerData);

            towerButtons.Add(button);
        }

        private void RefreshButtonsAvailability()
        {
            var currentMoney = gameManager.GetCurrentMoney();
            foreach (var towerButton in towerButtons)
            {
                towerButton.RefreshButtonAvailability(currentMoney);
            }
        }
    }
}
