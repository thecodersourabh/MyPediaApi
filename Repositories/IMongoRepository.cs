namespace Repositories;

public interface IMongoRepository<T>
{
    void Insert(T entity);
    void InsertMany(IEnumerable<T> entities);
    T GetById(object id);
    IEnumerable<T> GetAll();
}