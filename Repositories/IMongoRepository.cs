namespace Repositories;

public interface IMongoRepository<T>
{
    void Insert(T entity);
    void InsertMany(IEnumerable<T> entities);
    T GetById(object id);
    T GetByNameAndPassword(string name, string password);
    IEnumerable<T> GetAll();
}