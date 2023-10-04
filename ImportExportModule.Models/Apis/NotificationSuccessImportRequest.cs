using ImportExportModule.Models.Apis.NotificationsResultImport;

namespace ImportExportModule.Models.Apis;

/// <summary>
/// Тело запроса на уведомление модуля реестров и заявок об успешном импорте
/// </summary>
public class NotificationSuccessImportRequest : ResultImportRequest
{
    /// <summary>
    /// Количество успешно загруженных записей
    /// </summary>
    public int SuccessImportElements { get; private set; }

    /// ctor
    public NotificationSuccessImportRequest(Guid id, int successImportElements)
    {
        Id = id;
        SuccessImportElements = successImportElements;
    }
}