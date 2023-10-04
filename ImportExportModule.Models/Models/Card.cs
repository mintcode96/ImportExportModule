using ImportExportModule.Models.Interfaces;


namespace ImportExportModule.Models.Models;

/// <summary>
/// Модель карточки из реестра карт
/// </summary>
public class Card : ElementRegistry
{
    /// <summary>
    /// Номер карты
    /// </summary>
    public string CardNumber { get; private set; }
    
    /// <summary>
    /// ИмяФамилия держателя
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    public string? ExpirationDate { get; private set; }
    
    /// <summary>
    /// Сумма выплаты
    /// </summary>
    public double Sum { get; private set; }
    
    /// <summary>
    /// Внешний идентификатор
    /// </summary>
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