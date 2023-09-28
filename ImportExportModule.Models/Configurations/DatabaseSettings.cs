namespace ImportExportModule.Models.Configurations;

/// <summary>
/// Класс параметров подключения к монге
/// </summary>
public class DatabaseSettings
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    public string ConnectionString { get; set; } = null!;
    
    /// <summary>
    /// Название бд
    /// </summary>
    public string DatabaseName { get; set; } = null!;
    
    /// <summary>
    /// Название коллекции в монге
    /// </summary>
    public string CollectionName { get; set; } = null!;
}