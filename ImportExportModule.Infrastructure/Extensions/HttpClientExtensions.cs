namespace ImportExportModule.Infrastructure.Extensions;

/// <summary>
/// Методы расширений для Http клиентов
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Добавление базового адреса сервиса
    /// </summary>
    public static HttpClient WithBaseAddress(this HttpClient httpClient, string url)
    {
        if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));
        if (string.IsNullOrEmpty(url)) throw new ArgumentException(null, nameof(url));

        httpClient.BaseAddress = new Uri(url);

        return httpClient;
    }
}