namespace ImportExportModule.Application.Errors;

/// <summary>
/// Такой реестр уже обнаружен в бд
/// </summary>
public class RegistryAlreadyExistError: ErrorResponse
{
    /// <summary>
    /// Title
    /// </summary>
    public const string Details = "Такой реестр уже существует";
    
    /// <summary>
    /// Title
    /// </summary>
    public const string TitleContent = "Ошибка при загрузке реестра";

    /// <inheritdoc />
    public RegistryAlreadyExistError() : base(TitleContent, Details)
    {
    }
}