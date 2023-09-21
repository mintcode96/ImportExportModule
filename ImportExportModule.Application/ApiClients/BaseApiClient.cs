namespace ImportExportModule.Application.ApiClients;

/// <summary>
/// Базовый класс API клиентов
/// </summary>
public class BaseApiClient
{
    /// <summary>
    /// HttpClient
    /// </summary>
    protected readonly HttpClient? HttpClient;
    
    /// <summary>ctor</summary>
    protected BaseApiClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    
    /// <summary>ctor</summary>
    protected BaseApiClient() { }

    /// <summary>
    /// Парсинг полученного ответа в необходимый класс
    /// </summary>
    /// <param name="message">ответ от сервиса</param>
    /// <typeparam name="T">Тип ожидаемого ответа</typeparam>
    /// <exception cref="InvalidOperationException">Тип ответа не соответствует ожидаемому</exception>
    protected static async Task<T> ParseResponseAsync<T>(HttpResponseMessage message)
    {
        if (message.IsSuccessStatusCode)
            return await message.Content.TryReadAsAsync<T>() ??
                   throw new InvalidOperationException(
                       $"Response content is not of {typeof(T)} type.");

        var content = await message.Content.ReadAsStringAsync();

        throw new HttpStatusCodeException(message.StatusCode,
            string.IsNullOrEmpty(content) ?
                $"Content message is empty. Response status code is {(int)message.StatusCode} - {message.StatusCode}" :
                content);
    }
    
    /// <summary>
    /// Создание httpContent для POST запросов
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    protected static HttpContent CreateHttpPostContent(object body) =>
        new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
}
