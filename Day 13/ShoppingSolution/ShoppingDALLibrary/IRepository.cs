namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
        Task<T> Add(T item);
        Task<List<T>> GetAll();
        Task<T> GetByKey(K id);
        Task<T> Update(T item);
        Task<T> Delete(K key);
    }
}
