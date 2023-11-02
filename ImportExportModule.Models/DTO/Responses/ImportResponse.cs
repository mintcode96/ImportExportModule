using System.Text.Json.Serialization;

namespace ImportExportModule.Models.DTO.Responses;

/// <summary>
/// Результат ипорта
/// </summary>
public class ImportResponse
{
    /// <summary>
    /// Идентификатор реестра
    /// </summary>
    [JsonPropertyName("registry_id")]
    public Guid RegistryId { get; private set; }
    
    /// <summary>
    /// Количество успешно загруженных записей
    /// </summary>
    [JsonPropertyName("success_import_elements")]
    public int SuccessImportElements { get; private set; }

    /// ctor
    public ImportResponse(Guid registryId, int successImportElements)
    {
        SuccessImportElements = successImportElements;
        RegistryId = registryId;
    }
}