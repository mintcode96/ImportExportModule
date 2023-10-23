using System.ComponentModel.DataAnnotations;

namespace ImportExportModule.Models.Configurations;

/// <summary>
/// Настройки для url модуля реестров и заявок
/// </summary>
public class RegistriesAndApplicationSettings
{
    /// <summary>
    /// Базовый урл приложения
    /// </summary>
    [Required]
    public string BaseUrl { get; set; } = string.Empty;
}