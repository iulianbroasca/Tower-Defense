using System.Collections.Generic;
using ObjectPool.Interfaces;
using UnityEngine;

namespace ObjectPool.BaseScripts
{
    public abstract class BaseObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
    {
        protected readonly Queue<T> pool = new Queue<T>();
        protected T component;

        public virtual void RegisterComponent(T component)
        {
            this.component = component;
        }

        public virtual T GetObjectFromPool()
        {
            LazyInstantiation();
            var element = pool.Dequeue();
            element.gameObject.SetActive(true);
            return element;
        }

        public virtual void AddObjectToPool(T component)
        {
            InstantiateAndEnqueueComponent(component);
        }

        private void LazyInstantiation()
        {
            if (pool.Count > 0)
                return;

            InstantiateAndEnqueueComponent(Instantiate(component));
        }

        private void InstantiateAndEnqueueComponent(T component)
        {
            component.gameObject.SetActive(false);
            pool.Enqueue(component);
        }
    }
}
