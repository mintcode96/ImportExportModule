using ImportExportModule.Models.Apis;
using ImportExportModule.Models.Configurations;

namespace ImportExportModule.Application.ApiClients;

public interface IServiceApiClient
{
    Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken);
}

public class ServiceApiClient : BaseApiClient, IServiceApiClient
{
    private HttpClient _httpClient;
    private readonly IOptions<RegistriesAndApplicationSettings> RegistriesAndApplicationSettings;
    
    public ServiceApiClient(HttpClient httpClient, IOptions<RegistriesAndApplicationSettings> registriesAndApplicationSettings):base(httpClient)
    {
        RegistriesAndApplicationSettings = registriesAndApplicationSettings;
    }
    
    public async Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken)
    {
        var url = RegistriesAndApplicationSettings.Value.BaseUrl + RegistriesAndApplicationSettings.Value.NotifyUrl;
        
        await _httpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);
    }
}