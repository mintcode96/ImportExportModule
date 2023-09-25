using System.Text.Json.Serialization;
using ImportExportModule.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Models.DTO.Requests;

/// <summary>
/// Тело запроса на импорт реестра
/// </summary>
public class ImportRequest
{
    /// <summary>
    /// Внешний идентификатор
    /// </summary>
    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Название реестра
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Валюта - всегда RUB
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }
    
    /// <summary>
    /// Валюта - всегда RUB
    /// </summary>
    [JsonPropertyName("type")]
    public RegistryType Type { get; set; }

    /// <summary>
    /// список мерчей
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public Guid? MerchantId { get; set; }

    /// <summary>
    /// Загружаемый реестр
    /// </summary>
    [JsonPropertyName("registry")]
    public IFormFile Registry{ get; set; }
}