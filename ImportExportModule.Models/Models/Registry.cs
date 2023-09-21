using ImportExportModule.Models.Enums;
using ImportExportModule.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImportExportModule.Models.Models;

public class Registry
{
    public Registry(RegistryType? registryType, string? registryName, Guid? merchantId, Currency? currency)
    {
        Id = ObjectId.GenerateNewId(DateTime.UtcNow).ToString();
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }
    
    [BsonRepresentation(BsonType.String)]
    public RegistryType? RegistryType { get; private set; }
    
    public string? RegistryName { get; private set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid? MerchantId { get; private set; }

    [BsonRepresentation(BsonType.String)]
    public Currency? Currency { get; private set; }

    public List<ElementRegistry> Elements { get; set; }
    
}