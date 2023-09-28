using ImportExportModule.Models.Interfaces;

namespace ImportExportModule.Application.Rabbit.Events;

/// <summary>
/// Эвент об успешной загрузки
/// </summary>
public class SuccessImportEvent
{
    /// ctor
    public SuccessImportEvent(Guid id, string? registryType, string? registryName, Guid? merchantId, string? currency,
        List<ElementRegistry> elements)
    {
        Id = id;
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
        Elements = elements;
    }

    /// <summary>
    /// Внутренний идентификатор
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Тип реестра
    /// </summary>
    public string? RegistryType { get; private set; }

    /// <summary>
    /// Название реестра
    /// </summary>
    public string? RegistryName { get; private set; }

    /// <summary>
    /// Идентификатор мерчанта
    /// </summary>
    public Guid? MerchantId { get; private set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string? Currency { get;private set; }

    /// <summary>
    /// Строки реестра
    /// </summary>
    public List<ElementRegistry> Elements { get; set; }
}