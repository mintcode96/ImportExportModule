using System.Text.Json.Serialization;

namespace ImportExportModule.Models.Models;

/// <summary>
/// Модель карточки из реестра карт
/// </summary>
public class Card : ElementRegistry
{
    /// <summary>
    /// Номер карты
    /// </summary>
    [JsonPropertyName("card_number")]
    public string CardNumber { get; private set; }
    
    /// <summary>
    /// ИмяФамилия держателя
    /// </summary>
    [JsonPropertyName("full_name")]
    public string Name { get; private set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    [JsonPropertyName("expire_date")]
    public string? ExpirationDate { get; private set; }
    
    /// <summary>
    /// Сумма выплаты
    /// </summary>
    [JsonPropertyName("amount")]
    public double Sum { get; private set; }
    
    /// <summary>
    /// Внешний идентификатор
    /// </summary>
    [JsonPropertyName("external_id")]
    public string ExternalId { get; private set; }

    /// ctor
    public Card(string cardNumber, string name, string? expirationDate, double sum, string externalId)
    {
        Id = Guid.NewGuid();
        CardNumber = cardNumber;
        Name = name;
        ExpirationDate = expirationDate;
        Sum = sum;
        ExternalId = externalId;
    }
}