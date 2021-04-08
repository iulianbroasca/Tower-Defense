using Globals;
using MonoSingleton;
using ScriptableObjects;
using TowerMechanism.Models;
using UnityEngine;

namespace TowerMechanism.Managers
{
    public class TowerManager : MonoSingleton<TowerManager>
    {
        [SerializeField] private TowersContainer towers;
        [SerializeField] private Camera placementCamera;

        private TowerComponent currentTower;
        private bool placementStarted;
        private int mapLayer;
        private RaycastHit raycastHit;

        protected override void Awake()
        {
            base.Awake();
            mapLayer = LayerMask.GetMask(Constants.Layers.Map);
        }

        private void FixedUpdate()
        {
            if (placementStarted && Physics.Raycast(placementCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, mapLayer))
            {
                PlaceOnMap(raycastHit);
                if (Input.GetMouseButton(0))
                {
                    StopPlacement(raycastHit);
                }
            }
        }

        public void StartPlacement(int towerId)
        {
            placementStarted = true;

            if(currentTower != null)
                DestroyImmediate(currentTower.gameObject);

            InstantiateCurrentTower(towers.GetTower(towerId));
            currentTower.SetActiveTowerRange(true);
            //EnableRangeTower
        }

        public void StopPlacement(RaycastHit hit)
        {
            placementStarted = false;
            PlaceOnMap(hit);
            currentTower.SetActiveTowerRange(false);
            ResetCurrentTower();
        }

        public TowersContainer GetTowersContainer()
        {
            return towers;
        }

        private void PlaceOnMap(RaycastHit hit)
        {
            currentTower.transform.localPosition = hit.point;
        }

        private void ResetCurrentTower()
        {
            currentTower = null;
        }

        private void InstantiateCurrentTower(TowerItem towerItem)
        {
            currentTower = Instantiate(towerItem.TowerComponent);
            currentTower.SetTowerRangeBehaviour(towers.GetTowerRangeBehaviour(), towerItem.TowerData.Range);
        }

    }
}
