namespace GOOS_Sample.Repository
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}