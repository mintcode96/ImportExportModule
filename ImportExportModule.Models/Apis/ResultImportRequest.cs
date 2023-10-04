namespace ImportExportModule.Models.Apis.NotificationsResultImport;

/// <summary>
/// Нотификации окончания загрузки реестра
/// </summary>
public abstract class ResultImportRequest
{
    /// <summary>
    /// Идентификатор реестра
    /// </summary>
    public Guid Id { get; protected set; }
}