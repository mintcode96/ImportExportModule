using ImportExportModule.Models.Apis;
using ImportExportModule.Models.Apis.NotificationsResultImport;
using ImportExportModule.Models.Configurations;

namespace ImportExportModule.Application.ApiClients;

/// <summary>
/// Апи клиент
/// </summary>
public interface IServiceApiClient
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

/// <summary>
/// Апи клиент
/// </summary>
public class ServiceApiClient : BaseApiClient, IServiceApiClient
{
    private readonly IOptions<RegistriesAndApplicationSettings> _registriesAndApplicationSettings;

    /// ctor
    public ServiceApiClient(HttpClient httpClient,
        IOptions<RegistriesAndApplicationSettings> registriesAndApplicationSettings) : base(httpClient)
    {
        _registriesAndApplicationSettings = registriesAndApplicationSettings;
    }

    /// <inheritdoc />
    public async Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken)
    {
        var url = _registriesAndApplicationSettings.Value.BaseUrl + _registriesAndApplicationSettings.Value.NotifyStartImportUrl;

        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }

    /// <inheritdoc />
    public async Task NotificationSuccessImportAsync(NotificationSuccessImportRequest request, CancellationToken cancellationToken)
    {
        var url = _registriesAndApplicationSettings.Value.BaseUrl + _registriesAndApplicationSettings.Value.NotifySuccessImportUrl;
        
        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }
    
    /// <inheritdoc />
    public async Task NotificationErrorImportAsync(NotificationErrorImportRequest request, CancellationToken cancellationToken)
    {
        var url = _registriesAndApplicationSettings.Value.BaseUrl + _registriesAndApplicationSettings.Value.NotifyErrorImportUrl;
        
        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }
}