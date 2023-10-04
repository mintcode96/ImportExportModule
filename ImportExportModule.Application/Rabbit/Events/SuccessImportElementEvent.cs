using ImportExportModule.Models.Interfaces;

namespace ImportExportModule.Application.Rabbit.Events;

/// <summary>
/// Эвент об успешной загрузки
/// </summary>
public class SuccessImportElementEvent
{
    /// ctor
    public SuccessImportElementEvent(Guid id,
        ElementRegistry element)
    {
        Id = id;
        Element = element;
    }

    /// <summary>
    /// Внутренний идентификатор
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Строки реестра
    /// </summary>
    public ElementRegistry Element { get; set; }
}