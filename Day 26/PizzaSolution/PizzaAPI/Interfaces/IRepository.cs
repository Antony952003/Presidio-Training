namespace PizzaAPI.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Get(K key);
        Task<IEnumerable<T>> Get();
        Task<T> Update(T entity);
    }
}
