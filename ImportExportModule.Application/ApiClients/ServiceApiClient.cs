using ImportExportModule.Models.Apis;
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
}

/// <summary>
/// Апи клиент
/// </summary>
public class ServiceApiClient : BaseApiClient, IServiceApiClient
{
    private readonly IOptions<RegistriesAndApplicationSettings> _registriesAndApplicationSettings;
    
    /// ctor
    public ServiceApiClient(HttpClient httpClient, IOptions<RegistriesAndApplicationSettings> registriesAndApplicationSettings):base(httpClient)
    {
        _registriesAndApplicationSettings = registriesAndApplicationSettings;
    }

    /// <inheritdoc />
    public async Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken)
    {
        var url = _registriesAndApplicationSettings.Value.BaseUrl + _registriesAndApplicationSettings.Value.NotifyUrl;
        
        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }
}