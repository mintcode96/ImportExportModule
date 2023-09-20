using ImportExportModule.Models.Enums;
using ImportExportModule.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImportExportModule.Models.Models;

public class Registry
{
    [BsonRepresentation(BsonType.String)]
    public RegistryType? RegistryType { get; set; }
    
    public string? RegistryName { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid? MerchantId { get; set; }

    public Currency? Currency { get; set; }

    public List<ElementRegistry> Elements { get; set; }
}