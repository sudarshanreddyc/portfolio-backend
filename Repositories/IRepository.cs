namespace Portfolio.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
