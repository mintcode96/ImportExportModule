namespace ImportExportModule.Application.Errors;

public class ImportError : ErrorResponse
{
    /// <summary>
    /// Title
    /// </summary>
    public const string TitleContent = "Во время загрузки реестра произошла ошибка";

    /// <inheritdoc />
    public ImportError() : base(TitleContent)
    {
    }
}