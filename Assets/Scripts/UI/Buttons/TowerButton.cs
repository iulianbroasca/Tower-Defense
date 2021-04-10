using TowersMechanism.Managers;
using TowersMechanism.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class TowerButton : MonoBehaviour
    {
        [SerializeField] private Text towerNameText;
        [SerializeField] private Text towerPriceText;
        [SerializeField] private Button button;

        private float towerPrice;

        public void InitializationButton(TowerData towerData)
        {
            SetText(towerNameText, towerData.Name);
            SetButton(towerData.Id);
            SetPrice(towerData.Price);
            SetText(towerPriceText, towerPrice.ToString());
        }

        public void RefreshButtonAvailability(float currentMoney)
        {
            button.interactable = currentMoney >= towerPrice;
        }

        private void SetText(Text text, string value)
        {
            text.text = value;
        }

        private void SetPrice(float price)
        {
            towerPrice = price;
        }

        private void SetButton(int towerId)
        {
            button.onClick.AddListener(() =>
            {
                TowersManager.Instance.StartPlacement(towerId);
            });
        }
    }
}
