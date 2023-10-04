namespace ImportExportModule.Models.DTO.Responses;

/// <summary>
/// Результат ипорта
/// </summary>
public class ImportResponse
{
    /// <summary>
    /// Идентификатор реестра
    /// </summary>
    public Guid RegistryId { get; private set; }
    
    /// <summary>
    /// Количество успешно загруженных записей
    /// </summary>
    public int SuccessImportElements { get; private set; }

    /// ctor
    public ImportResponse(Guid registryId, int successImportElements)
    {
        SuccessImportElements = successImportElements;
        RegistryId = registryId;
    }
}