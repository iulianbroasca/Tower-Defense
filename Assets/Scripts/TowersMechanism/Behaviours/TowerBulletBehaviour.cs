using System.Collections;
using BalloonsMechanism.Components;
using Globals;
using TowersMechanism.Managers;
using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerBulletBehaviour : MonoBehaviour
    {
        private Coroutine coroutine; 
        private Rigidbody rigidbody;

        private bool touched;
        public Rigidbody RigidbodyComponent
        {
            get
            {
                if (rigidbody == null)
                    rigidbody = GetComponent<Rigidbody>();
                return rigidbody;
            }
        }

        private void OnEnable()
        {
            touched = false;
        }

        public void Attack(Vector3 towerPosition, Vector3 targetPosition, float bulletSpeed)
        {
            transform.position = towerPosition;
            RigidbodyComponent.velocity = bulletSpeed * (targetPosition - towerPosition).normalized;
            coroutine = StartCoroutine(Destroy());
        }

        private void ResetRigidbody()
        {
            RigidbodyComponent.velocity = Vector3.zero;
            RigidbodyComponent.angularVelocity = Vector3.zero;
        }
        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(Constants.BulletLife);
            TowersManager.Instance.GetBulletsPool().AddObjectToPool(this);
        }

        private void OnDisable()
        {
            if (coroutine!=null)
                StopCoroutine(coroutine);
            ResetRigidbody();
        }

        private void OnCollisionEnter(Collision other)
        {
            if(touched)
               return;
             
            var balloon = other.gameObject.GetComponentInParent<BalloonComponent>();
            if (balloon != null)
            {
                balloon.BalloonTouched();
            }

            touched = true;
        }
    
    }
}
