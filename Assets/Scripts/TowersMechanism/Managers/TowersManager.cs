using System.Collections.Generic;
using Game.Managers;
using Globals;
using MonoSingleton;
using ScriptableObjects;
using TowersMechanism.Components;
using TowersMechanism.Models;
using UI.Managers;
using UI.Screens.Game;
using UnityEngine;

namespace TowersMechanism.Managers
{
    public class TowersManager : MonoSingleton<TowersManager>
    {
        [SerializeField] private TowersContainer towers;
        [SerializeField] private LayerMask layers;

        private bool placementStarted;

        private Camera placementCamera;
        private RaycastHit raycastHit;
        
        private GameScreen gameScreen;
        private BulletsPool bulletsPool;
        private TowerItem currentTower;

        private List<TowerComponent> towersInScene = new List<TowerComponent>();

        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        private void Start()
        {
            gameScreen = (GameScreen)ScreensManager.Instance.GetScreen(typeof(GameScreen));
        }

        private void FixedUpdate()
        {
            if (!placementStarted || !Physics.Raycast(placementCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, layers)) 
                return;

            PlaceOnMap(raycastHit);

            if (!IsOnMap())
                return;

            if (Input.GetMouseButton(0))
            {
                StopPlacement(raycastHit);
            }
        }

        public void StartPlacement(int towerId)
        {
            placementStarted = true;

            if(currentTower != null)
                DestroyImmediate(currentTower.TowerComponent.gameObject);

            InstantiateCurrentTower(towers.GetTowerItem(towerId));
            currentTower.TowerComponent.SetActiveTowerRange(true);

            GameManager.Instance.BuyTower(currentTower.TowerData.Price);
            gameScreen.SetActiveGameModeScreen(false);
        }

        public void StopPlacement(RaycastHit hit)
        {
            placementStarted = false;
            PlaceOnMap(hit);
            currentTower.TowerComponent.SetActiveTowerRange(false);
            currentTower.TowerComponent.SetColorOnRange(Constants.ColorRangeOnMap);
            towersInScene.Add(currentTower.TowerComponent);
            ResetCurrentTower();
            gameScreen.SetActiveGameModeScreen(true);
        }

        public BulletsPool GetBulletsPool()
        {
            return bulletsPool;
        }

        public TowersContainer GetTowersContainer()
        {
            return towers;
        }

        public void RestartGame()
        {
            ClearTowersFromScene();
        }

        private bool IsOnMap()
        {
            var isOnMap = LayerMask.LayerToName(raycastHit.transform.gameObject.layer).Equals(Constants.MapLayer);

            currentTower.TowerComponent.SetColorOnRange(isOnMap ? Constants.ColorRangeOnMap : Constants.ColorRangeOutsideMap);
            return isOnMap;
        }

        private void ClearTowersFromScene()
        {
            foreach (var tower in towersInScene)
            {
                DestroyImmediate(tower.gameObject);
            }
            towersInScene.Clear();
        }

        private void PlaceOnMap(RaycastHit hit)
        {
            currentTower.TowerComponent.transform.localPosition = hit.point;
        }

        private void ResetCurrentTower()
        {
            currentTower = null;
        }

        private void InstantiateCurrentTower(TowerItem towerItem)
        {
            currentTower = new TowerItem
            {
                TowerComponent = Instantiate(towerItem.TowerComponent), 
                TowerData = towerItem.TowerData
            };

            currentTower.TowerComponent.SetTowerRangeBehaviour(towers.GetTowerRangeBehaviour(),
                currentTower.TowerData.Range, currentTower.TowerData.BulletLoadingTime);

            currentTower.TowerComponent.SetTowerAttackBehaviour(towers.GetTowerAttackBehaviour(),
                currentTower.TowerData.BulletSpeed);
        }

        private void Initialize()
        {
            placementCamera = Camera.main;
            bulletsPool = gameObject.AddComponent<BulletsPool>();
            bulletsPool.RegisterComponent(towers.GetTowerBulletBehaviour());
        }
    }
}
