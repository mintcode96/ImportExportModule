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
    public string CardNumber { get; set; }
    
    /// <summary>
    /// ИмяФамилия держателя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    public string? ExpirationDate { get; set; }
    
    /// <summary>
    /// Сумма выплаты
    /// </summary>
    public double Sum { get; set; }
    
    /// <summary>
    /// Внешний идентификатор
    /// </summary>
    public string ExternalId { get; set; }
}