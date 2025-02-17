using System;
using System.Collections;
using Globals;
using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerRangeBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject rangeGameObject;

        private float radius;
        private float bulletLoadingTime;
        private int balloonLayer;
        private bool loading;
        private Color currentColor = Color.white;
        private Collider[] balloons;
        private Action<Collider[], int> detectedBalloons;

        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if(loading)
                return;

            var numBalloons = Physics.OverlapSphereNonAlloc(transform.position, radius, balloons, balloonLayer);
            if (numBalloons <= 0) 
                return;

            loading = true;
            detectedBalloons.Invoke(balloons, numBalloons);
        }

        public void SetRangeData(Vector3 position, Vector3 scale, float range, float bulletLoadingTime)
        {
            transform.localPosition = position;
            transform.localScale = new Vector3(1 / scale.x, 1 / scale.y, 1 / scale.y) * range;
            radius = range / 2.0f;
            this.bulletLoadingTime = bulletLoadingTime;
        }

        public void SetActiveRangeGameObject(bool value)
        {
            rangeGameObject.SetActive(value);
        }

        public void RegisterEventDetectedBalloons(Action<Collider[], int> action)
        {
            if (detectedBalloons == null)
            {
                detectedBalloons = action;
            }
        }

        public void SetColorOnRangeGameObject(Color color)
        {
            if(currentColor == color)
                return;
            rangeGameObject.GetComponent<MeshRenderer>().material.color = color;
        }

        private IEnumerator LoadBullets()
        {
            while (true)
            {
                yield return new WaitUntil(()=>loading);
                yield return new WaitForSeconds(bulletLoadingTime);
                loading = false;
            }
        }

        private void Initialize()
        {
            balloonLayer = LayerMask.GetMask(Constants.BalloonLayer);
            balloons = new Collider[Constants.MaxBullets];
            StartCoroutine(LoadBullets());
        }
    }
}
