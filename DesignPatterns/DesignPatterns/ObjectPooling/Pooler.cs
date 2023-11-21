namespace DesignPatterns.ObjectPooling
{
    public abstract class Pooler<T>
    {
        protected int poolMaxSize;

        protected Queue<T> pool;

        public Pooler(int poolMaxSize)
        {
            this.poolMaxSize = poolMaxSize;
            pool = new Queue<T>(this.poolMaxSize);
        }

        public virtual T Get()
        {
            if (pool.Count <= 0)
            {
                CreateNewObject();
            }

            T obj = pool.Dequeue();
            return obj;
        }

        protected abstract void CreateNewObject();

        public virtual void ReturnToPool(T obj)
        {
            if (pool.Count >= poolMaxSize) 
            {
                return;
            }

            pool.Enqueue(obj);
        }
    }
}
