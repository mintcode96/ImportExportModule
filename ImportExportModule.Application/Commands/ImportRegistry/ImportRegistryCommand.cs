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
    /// Идентификатор клиента создавшего
    /// </summary>
    public Guid? MemberId { get; private set; }

    /// ctor
    public ImportRegistryCommand(ImportRequest importParameters, Guid? memberId)
    {
        ImportParameters = importParameters;
        MemberId = memberId;
    }
}