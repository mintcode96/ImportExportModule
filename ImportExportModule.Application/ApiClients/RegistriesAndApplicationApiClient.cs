using ImportExportModule.Models.Apis;

namespace ImportExportModule.Application.ApiClients;

/// <inheritdoc cref="ImportExportModule.Application.ApiClients.IRegistriesAndApplicationApiClient" />
public class RegistriesAndApplicationApiClient : BaseApiClient, IRegistriesAndApplicationApiClient
{
    /// ctor
    public RegistriesAndApplicationApiClient(HttpClient httpClient) : base(httpClient) { }

    /// <inheritdoc />
    public async Task NotificationStartImportAsync(
        NotificationStartImportRequest request, CancellationToken cancellationToken)
    {
        const string url = "/registry/create";

        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }

    /// <inheritdoc />
    public async Task NotificationSuccessImportAsync(NotificationSuccessImportRequest request, CancellationToken cancellationToken)
    {
        const string url = "/registry/success";
        
        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }
    
    /// <inheritdoc />
    public async Task NotificationErrorImportAsync(NotificationErrorImportRequest request, CancellationToken cancellationToken)
    {
        const string url = "/registry/error";
        
        var result = await HttpClient.PostAsync(url, CreateHttpPostContent(request), cancellationToken);

        await result.ThrowIfNotSuccessStatusCode();
    }
}