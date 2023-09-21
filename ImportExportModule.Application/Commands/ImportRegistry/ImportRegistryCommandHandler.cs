using ImportExportModule.Application.ExcelParses;
using ImportExportModule.Application.Rabbit.Events;
using ImportExportModule.DataLayer.Services;

namespace ImportExportModule.Application.Commands.ImportRegistry;

/// <summary>
/// Хэндлер команды импорта реестров
/// </summary>
public class ImportRegistryCommandHandler : IRequestHandler<ImportRegistryCommand, Result<ImportResponse>>
{
    private readonly RegistryMongoService _registryMongoService;
    private readonly IExcelParser _cardRegistryParser;

    private readonly IRabbitMqProducer<SuccessImportEvent> _successImportProducer;

    /// <summary>
    /// ctor
    /// </summary>
    public ImportRegistryCommandHandler(RegistryMongoService registryMongoService,
        IExcelParser cardRegistryParser, IRabbitMqProducer<SuccessImportEvent> successImportProducer)
    {
        _registryMongoService = registryMongoService;
        _cardRegistryParser = cardRegistryParser;
        _successImportProducer = successImportProducer;
    }

    public async Task<Result<ImportResponse>> Handle(ImportRegistryCommand request, CancellationToken cancellationToken)
    {
        var elements = await _cardRegistryParser.Parse(request.ImportRegistry);
        var registry = new Registry()
        {
            Elements = elements.ToList(),
            Currency = request.ImportParameters.Currency,
            MerchantId = request.ImportParameters.MerchantId,
            RegistryName = request.ImportParameters.Name,
            RegistryType = request.ImportParameters.Type
        };

        await _registryMongoService.CreateAsync(registry);

        _successImportProducer.Publish(new SuccessImportEvent(registry.RegistryType.ToString(), 
            registry.RegistryName, registry.MerchantId, registry.Currency.ToString(), registry.Elements));

        return new ImportResponse();
    }
}