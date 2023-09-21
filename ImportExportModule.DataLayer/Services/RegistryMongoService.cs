using ImportExportModule.Models.Configurations;
using ImportExportModule.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ImportExportModule.DataLayer.Services;

/// <summary>
/// Сервис для работы с коллекцией реестров в монге
/// </summary>
public class RegistryMongoService
{
    private readonly IMongoCollection<Registry> _registryCollection;
    
    /// ctor
    public RegistryMongoService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _registryCollection = mongoDb.GetCollection<Registry>(databaseSettings.Value.CollectionName);
    }

    /// <summary>
    /// Загрузить данные по реестру в бдшку
    /// </summary>
    /// <param name="registry"></param>
    public async Task CreateAsync(Registry registry) => await _registryCollection.InsertOneAsync(registry);
}