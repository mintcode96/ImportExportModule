namespace ImportExportModule.Models.Apis;

public class NotificationStartImportRequest
{
    public NotificationStartImportRequest(string id, string? registryType, string? registryName, Guid? merchantId,
        string? currency)
    {
        Id = id;
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
    }

    public string Id { get; private set; }

    public string? RegistryType { get; private set; }

    public string? RegistryName { get; private set; }

    public Guid? MerchantId { get; private set; }

    public string? Currency { get; private set; }
}