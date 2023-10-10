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
    [JsonProperty("registry_id")]
    public Guid Id { get; private set; }

    /// <summary>
    /// Строки реестра
    /// </summary>
    [JsonProperty("card")]
    public ElementRegistry Element { get; set; }
}