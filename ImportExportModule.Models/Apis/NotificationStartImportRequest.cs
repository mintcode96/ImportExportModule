namespace ImportExportModule.Models.Apis;

/// <summary>
/// Тело запроса на уведомление модуля реестров и заявок
/// </summary>
public class NotificationStartImportRequest
{
    /// <summary>
    /// Идентификатор реестра(objectId)
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// Тип реестра
    /// </summary>
    public string? RegistryType { get; private set; }

    /// <summary>
    /// Наименование реестра
    /// </summary>
    public string? RegistryName { get; private set; }

    /// <summary>
    /// Идентификатор мерчанта
    /// </summary>
    public Guid? MerchantId { get; private set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string? Currency { get; private set; }

    /// <summary>
    /// Идентификатор клиента создавшего платеж
    /// </summary>
    public Guid MemberId { get; private set; }
    
    public NotificationStartImportRequest(string id, string? registryType, string? registryName, Guid? merchantId,
        string? currency, Guid memberId)
    {
        Id = id;
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
        MemberId = memberId;
    }
}