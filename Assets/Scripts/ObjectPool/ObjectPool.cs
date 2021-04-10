using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool<T>: MonoBehaviour where T : MonoBehaviour
    {
        private readonly Queue<T> pool = new Queue<T>();
        private T component;

        public void RegisterComponent(T obj)
        {
            component = obj;
        }

        public T GetObjectFromPool()
        {
            LazyInstantiation();

            var element = pool.Dequeue();
            element.gameObject.SetActive(true);
            return element;
        }

        public void AddObjectToPool(T element)
        {
            element.gameObject.SetActive(false);
            pool.Enqueue(element);
        }

        private void LazyInstantiation()
        {
            if (pool.Count > 0)
                return;

            AddObjectToPool(Instantiate(component));
        }
    }
}
