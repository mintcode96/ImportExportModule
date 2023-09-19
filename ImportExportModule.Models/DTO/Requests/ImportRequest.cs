using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Models.DTO.Requests;

/// <summary>
/// Тело запроса на получение реестров
/// </summary>
public class ImportRequest
{
    /// <summary>
    /// Файл
    /// </summary>
    public IFormFile File { get; set; }

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
    public string Currency { get; set; }

    /// <summary>
    /// список мерчей
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public Guid? MerchantId { get; set; }
}