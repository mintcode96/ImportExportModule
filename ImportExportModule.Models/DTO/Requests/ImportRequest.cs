using ImportExportModule.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Models.DTO.Requests;

/// <summary>
/// Тело запроса на импорт реестра
/// </summary>
public class ImportRequest
{
    /// <summary>
    /// Название реестра
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Валюта - всегда RUB
    /// </summary>
    public Currency Currency { get; set; }
    
    /// <summary>
    /// Валюта - всегда RUB
    /// </summary>
    public RegistryType Type { get; set; }

    /// <summary>
    /// список мерчей
    /// </summary>
    public Guid? MerchantId { get; set; }

    /// <summary>
    /// Загружаемый реестр
    /// </summary>
    public IFormFile Registry { get; set; }
}