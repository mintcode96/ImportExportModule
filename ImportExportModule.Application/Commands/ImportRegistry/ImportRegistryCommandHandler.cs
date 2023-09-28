using ImportExportModule.Application.ApiClients;
using ImportExportModule.Application.ExcelParses;
using ImportExportModule.Application.Rabbit.Events;
using ImportExportModule.DataLayer.Services;
using ImportExportModule.Models.Apis;

namespace ImportExportModule.Application.Commands.ImportRegistry;

/// <summary>
/// Хэндлер команды импорта реестров
/// </summary>
public class ImportRegistryCommandHandler : IRequestHandler<ImportRegistryCommand, Result<ImportResponse>>
{
    private readonly RegistryMongoService _registryMongoService;
    private readonly IExcelParser _cardRegistryParser;
    private readonly IServiceApiClient _apiClient;

    private readonly IRabbitMqProducer<SuccessImportEvent> _successImportProducer;

    /// ctor
    public ImportRegistryCommandHandler(RegistryMongoService registryMongoService,
        IExcelParser cardRegistryParser, IRabbitMqProducer<SuccessImportEvent> successImportProducer,
        IServiceApiClient apiClient)
    {
        _registryMongoService = registryMongoService;
        _cardRegistryParser = cardRegistryParser;
        _successImportProducer = successImportProducer;
        _apiClient = apiClient;
    }

    /// <inheritdoc />
    public async Task<Result<ImportResponse>> Handle(ImportRegistryCommand request, CancellationToken cancellationToken)
    {
        var registry = new Registry(request.ImportParameters.Type, request.ImportParameters.Name,
            request.ImportParameters.MerchantId, request.ImportParameters.Currency);

        //todo: Сделать валидацию вообще таблицы, могут быть траблы с данными + обсудить с ребятами

        await _apiClient.NotificationStartImportAsync(
            new NotificationStartImportRequest(registry.Id, registry.RegistryType.ToString(), registry.RegistryName,
                registry.MerchantId, registry.Currency.ToString(), request.MemberId.Value), cancellationToken);

        var elements = await _cardRegistryParser.Parse(request.ImportParameters.Registry);

        registry.Elements = elements.ToList();

        await _registryMongoService.CreateAsync(registry);

        _successImportProducer.Publish(new SuccessImportEvent(registry.Id, registry.RegistryType.ToString(),
            registry.RegistryName, registry.MerchantId, registry.Currency.ToString(), registry.Elements));

        return new ImportResponse();
    }
}