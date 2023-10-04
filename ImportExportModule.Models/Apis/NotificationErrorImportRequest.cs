using ImportExportModule.Models.Apis.NotificationsResultImport;

namespace ImportExportModule.Models.Apis;

/// <summary>
/// Тело запроса на уведомление модуля реестров и заявок об ошибке  импорте
/// </summary>
public class NotificationErrorImportRequest : ResultImportRequest
{
    /// <summary>
    /// Текст ошибки
    /// </summary>
    public const string Error = "Ошибка при загрузке реестра";

    /// ctor
    public NotificationErrorImportRequest(Guid id)
    {
        Id = id;
    }
}