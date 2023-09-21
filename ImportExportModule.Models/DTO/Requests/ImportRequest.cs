using System.Text.Json.Serialization;
using ImportExportModule.Models.Enums;

namespace ImportExportModule.Models.DTO.Requests;

// TODO комментарии, иначе потом ахуеем жить
public class ImportRequest
{
    /// <summary>
    /// Внешний идентификатор
    /// </summary>
    [JsonPropertyName("external_id")] // TODO не смущает, что тут json prop, а ты передаешь как query?)
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
    /// использовать ли фейковую реализацию
    /// </summary>
    public bool UseFake { get; set; } // TODO вот это должно передаваться как кверя
}