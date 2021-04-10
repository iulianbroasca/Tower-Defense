namespace ObjectPool.Interfaces
{
    interface IObjectPool<T>
    {
        void RegisterComponent(T component);
        T GetObjectFromPool();
        void AddObjectToPool(T component);
    }
}
