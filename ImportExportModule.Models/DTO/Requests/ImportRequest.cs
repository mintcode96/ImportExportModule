using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Models.DTO.Requests;

/// <summary>
/// Тело запроса на получение реестров
/// </summary>
public class ImportRequest
{
    /// <summary>
    /// Файл
    /// </summary>
    public IFormFile File { get; set; }

    /// <summary>
    /// Внешний идентификатор
    /// </summary>
    public string ExternalId { get; set; }

    /// <summary>
    /// Название реестра
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Валюта - всегда RUB
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// список мерчей
    /// </summary>
    public Guid[] Merchants { get; set; }
}