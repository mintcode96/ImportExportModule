using ImportExportModule.Models.Apis;

namespace ImportExportModule.Application.ApiClients;

/// <summary>
/// Взаимодействие с сервисом реестров и заявок
/// </summary>
public interface IRegistriesAndApplicationApiClient
{
    /// <summary>
    /// Оповещение сервиса реестров и заявок о начале обработки файла
    /// </summary>
    Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Оповещение об успешной окончании загрузки реестра
    /// </summary>
    Task NotificationSuccessImportAsync(NotificationSuccessImportRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Оповещение об окончании загрузки реестра c ошибкой
    /// </summary>
    Task NotificationErrorImportAsync(NotificationErrorImportRequest request, CancellationToken cancellationToken);
}