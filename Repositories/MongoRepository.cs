using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repositories;

public class MongoRepository<T> : IMongoRepository<T>
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database,  ICollectionNames collectionNames)
    {
        _collection = database.GetCollection<T>(collectionNames.UserManagementCollection);
    }

    public void Insert(T entity)
    {
        _collection.InsertOne(entity);
    }

    public void InsertMany(IEnumerable<T> entities)
    {
        _collection.InsertMany(entities);
    }
    public T GetByNameAndPassword(string name, string password)
    {
        var filter = Builders<T>.Filter.Eq("EmailId", name) & Builders<T>.Filter.Eq("Password", password);
        return _collection.Find(filter).FirstOrDefault();
    }

    public T GetById(object id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        return _collection.Find(filter).FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        return _collection.Find(Builders<T>.Filter.Empty).ToList();
    }

}