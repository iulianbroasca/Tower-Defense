using System.Collections.Generic;
using TowerMechanism.Managers;
using TowerMechanism.Models;
using UI.BaseScripts;
using UI.Buttons;
using UnityEngine;

namespace UI.Screens
{
    public class TowersConfigurationScreen : BaseScreen
    {
        [SerializeField] private RectTransform contentPanel;
        [SerializeField] private TowerButton towerButton;

        private TowerManager towerManager;

        private void Awake()
        {
            towerManager = TowerManager.Instance;
            PopulateContentPanel(towerManager.GetTowersContainer().GetTowers());
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
            button.InitializationButton(towerItem);
        }
    }
}
