using ImportExportModule.Application.Configurations;
using ImportExportModule.Application.Models;

namespace ImportExportModule.Application.Services;

public class MongoDriverService
{
    private readonly IMongoCollection<Card> _cardCollection;
    
    public MongoDriverService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _cardCollection = mongoDb.GetCollection<Card>(databaseSettings.Value.CollectionName);
    }
}