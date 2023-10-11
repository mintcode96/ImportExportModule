using ImportExportModule.Models.Enums;

namespace ImportExportModule.Application.Rabbit.Events;

/// <summary>
/// Эвент об успешной загрузки
/// </summary>
public class SuccessImportElementEvent
{
    /// ctor
    public SuccessImportElementEvent(Guid registryId,
        PaymentType paymentType)
    {
        RegistryId = registryId;
        PaymentType = paymentType;
    }

    /// <summary>
    /// Внутренний идентификатор
    /// </summary>
    public Guid RegistryId { get; private set; }

    /// <summary>
    /// Строки реестра
    /// </summary>
    public PaymentType PaymentType { get; private set; }
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
    /// <summary>
    /// Название типа платежа
    /// </summary>
    public string NameType { get; private set; }
    
    /// <summary>
    /// Тип реестра для платежа
    /// </summary>
    public RegistryTypeEnum Type { get; private set; }
    
    /// <summary>
    /// Сам элемент платежа в реестрах и заявках
    /// </summary>
    public ElementRegistry Value { get; private set; }
    
    /// ctor
    public PaymentType(ElementRegistry value, string nameType, RegistryTypeEnum type)
    {
        Value = value;
        NameType = nameType;
        Type = type;
    }
}