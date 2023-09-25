namespace ImportExportModule.Application.Commands.ImportRegistry;

/// <summary>
/// Команда для импорта реестров
/// </summary>
public class ImportRegistryCommand : IRequest<Result<ImportResponse>>
{
    /// <summary>
    /// Параметры для импорта
    /// </summary>
    public ImportRequest ImportParameters { get; private set; }

    /// <summary>
    /// ctor
    /// </summary>
    public ImportRegistryCommand(ImportRequest importParameters)
    {
        ImportParameters = importParameters;
    }
}