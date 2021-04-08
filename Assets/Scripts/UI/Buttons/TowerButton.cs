using Globals;
using TowerMechanism.Managers;
using TowerMechanism.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class TowerButton : MonoBehaviour
    {
        [SerializeField] private Text textButton;
        [SerializeField] private Button button;

        private float towerPrice;

        public void InitializationButton(TowerItem towerItem)
        {
            SetText(towerItem.Name);
            SetButton(towerItem.Id);
            SetPrice(towerItem.TowerData.Price);
        }

        public void RefreshButtonAvailability()
        {
            gameObject.SetActive(Constants.PlayerMoney > towerPrice);
        }

        private void SetText(string towerName)
        {
            textButton.text = towerName;
        }

        private void SetPrice(float price)
        {
            towerPrice = price;
        }

        private void SetButton(int towerId)
        {
            button.onClick.AddListener(() =>
            {
                TowerManager.Instance.StartPlacement(towerId);
            });
        }
    }
}
