using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImportExportModule.Models.Models;

/// <summary>
/// Элемент реестра эквивалентен строке из него 
/// </summary>
public class ElementRegistry
{
    /// <summary>
    /// Идентификатор элемента реестра
    /// </summary>
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
}