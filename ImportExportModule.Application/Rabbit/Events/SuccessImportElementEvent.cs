using ImportExportModule.Models.Enums;

namespace ImportExportModule.Application.Rabbit.Events;

/// <summary>
/// Эвент об успешной загрузки
/// </summary>
public class SuccessImportElementEvent
{
    /// ctor
    public SuccessImportElementEvent(Guid id,
        PaymentType type)
    {
        Id = id;
        Type = type;
    }

    /// <summary>
    /// Внутренний идентификатор
    /// </summary>
    [JsonProperty("registry_id")]
    public Guid Id { get; private set; }

    /// <summary>
    /// Строки реестра
    /// </summary>
    [JsonProperty("payment_type")]
    public PaymentType Type { get; private set; }
}

/// <summary>
/// Тип платежа
/// </summary>
/// <remarks>для парсинга значения Value<br/></remarks>
/// <remarks><i>Возможные значения: <br/>
/// PaymentTypeCard<br/>
/// PaymentTypeCrypto<br/>
/// PaymentTypeSbp</i></remarks>
public class PaymentType
{
    /// ctor
    public PaymentType(ElementRegistry element, string nameType, RegistryType type)
    {
        Element = element;
        NameType = nameType;
        Type = type;
    }

    /// <summary>
    /// Сам элемент платежа в реестрах и заявках
    /// </summary>
    [JsonProperty("value")]
    public ElementRegistry Element { get; private set; }
    
    /// <summary>
    /// Тип реестра для платежа
    /// </summary>
    [JsonProperty("type")]
    public RegistryType Type { get; private set; }
    
    /// <summary>
    /// Название типа платежа
    /// </summary>
    [JsonProperty("name_type")]
    public string NameType { get; private set; }
}