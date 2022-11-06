using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Models;
using MongoDbExample.Options;

namespace MongoDbExample.Repositories;

public abstract class MongoDbRepository<T> : IRepository<T> where T : BaseMongoModel
{
    private readonly MongoDbSettings _mongoDbSettings;
    private readonly IMongoCollection<T> _collection;

    public MongoDbRepository(
        string collectionName,
        IOptions<MongoDbSettings> mongoDbSettings)
    {
        _mongoDbSettings = mongoDbSettings.Value;

        var mongoClient = new MongoClient(_mongoDbSettings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetByIdAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T entity) => await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(string id, T entity) => await _collection.ReplaceOneAsync(x => x.Id == id, entity);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
}
