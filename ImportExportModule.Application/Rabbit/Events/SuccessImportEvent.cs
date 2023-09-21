using ImportExportModule.Models.Interfaces;

namespace ImportExportModule.Application.Rabbit.Events;

public class SuccessImportEvent
{
    public SuccessImportEvent(string? registryType, string? registryName, Guid? merchantId, string? currency,
        List<ElementRegistry> elements)
    {
        RegistryType = registryType;
        RegistryName = registryName;
        MerchantId = merchantId;
        Currency = currency;
        Elements = elements;
    }

    public string? RegistryType { get; private set; }

    public string? RegistryName { get; private set; }

    public Guid? MerchantId { get; private set; }

    public string? Currency { get;private set; }

    public List<ElementRegistry> Elements { get; set; }
}