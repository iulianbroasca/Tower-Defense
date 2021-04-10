using System.Collections;
using BalloonsMechanism.Components;
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

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(3f);
            TowersManager.Instance.GetBulletsPool().AddObjectToPool(this);
        }

        public void Attack(Vector3 towerPosition, Vector3 targetPosition, float bulletSpeed)
        {
            transform.position = towerPosition;
            RigidbodyComponent.velocity = bulletSpeed * (targetPosition - towerPosition).normalized;
            coroutine = StartCoroutine(Destroy());
        }

        private void OnDisable()
        {
            if (coroutine!=null)
                StopCoroutine(coroutine);
            RigidbodyComponent.velocity = Vector3.zero;
            RigidbodyComponent.angularVelocity = Vector3.zero;
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
