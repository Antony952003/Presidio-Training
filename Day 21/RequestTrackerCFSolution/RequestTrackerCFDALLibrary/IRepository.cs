namespace RequestTrackerCFDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
        public Task<T> Add(T entity);
        public Task<T> Get(K key);
        public Task<IList<T>> GetAll();
        public Task<T> Delete(K key);
        public Task<T> Update(T entity);

    }
}
