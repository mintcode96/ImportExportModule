using ImportExportModule.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImportExportModule.Models.Models;

/// <summary>
/// Модель реестра
/// </summary>
public class Registry
{
    //сtor
    public Registry(RegistryType? registryType, string? registryName, Guid? merchantId, Currency? currency)
    {
        Id = Guid.NewGuid();
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
    }
    
    /// <summary>
    /// Внутренний идентификатор реестра в бд
    /// </summary>
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Тип реестра (пока что только реестр карт)
    /// </summary>
    [BsonRepresentation(BsonType.String)]
    public RegistryType? RegistryType { get; private set; }
    
    /// <summary>
    /// Название реестра передается с фронта
    /// </summary>
    public string? RegistryName { get; private set; }
    
    /// <summary>
    /// Идентификатор мерчанта
    /// </summary>
    [BsonRepresentation(BsonType.String)]
    public Guid? MerchantId { get; private set; }

    /// <summary>
    /// Валюта выплаты
    /// </summary>
    [BsonRepresentation(BsonType.String)]
    public Currency? Currency { get; private set; }

    /// <summary>
    /// Строки из реестра
    /// </summary>
    public List<ElementRegistry> Elements { get; set; }
    
}