namespace ImportExportModule.Models.Configurations;

/// <summary>
/// Настройки для url модуля реестров и заявок
/// </summary>
public class RegistriesAndApplicationSettings
{
    /// <summary>
    /// Базовый урл приложения
    /// </summary>
    public string BaseUrl { get; set; }
    
    /// <summary>
    /// кусок с методом для отправки уведомления о загрузке файла
    /// </summary>
    public string NotifyStartImportUrl { get; set; }
    
    /// <summary>
    /// кусок с методом для отправки уведомления о загрузке файла
    /// </summary>
    public string NotifySuccessImportUrl { get; set; }
    
    /// <summary>
    /// кусок с методом для отправки уведомления о загрузке файла
    /// </summary>
    public string NotifyErrorImportUrl { get; set; }
}