using ImportExportModule.Application.ApiClients;
using ImportExportModule.Application.Errors;
using ImportExportModule.Application.ExcelParses;
using ImportExportModule.Application.Rabbit.Events;
using ImportExportModule.DataLayer.Services;
using ImportExportModule.Models.Apis;
using ImportExportModule.Models.Apis.NotificationsResultImport;
using ImportExportModule.Models.Enums;

namespace ImportExportModule.Application.Commands.ImportRegistry;

/// <summary>
/// Хэндлер команды импорта реестров
/// </summary>
public class ImportRegistryCommandHandler : IRequestHandler<ImportRegistryCommand, Result<ImportResponse>>
{
    private readonly RegistryMongoService _registryMongoService;
    private readonly IExcelParser _cardRegistryParser;
    private readonly IServiceApiClient _apiClient;

    private readonly IRabbitMqProducer<SuccessImportElementEvent> _successImportProducer;

    /// ctor
    public ImportRegistryCommandHandler(RegistryMongoService registryMongoService,
        IExcelParser cardRegistryParser, IRabbitMqProducer<SuccessImportElementEvent> successImportProducer,
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
        
        // TODO проверь, что такого реестра с уникальным именем нет
        var registry = new Registry(request.ImportParameters.TypeEnum, request.ImportParameters.Name,
            request.ImportParameters.MerchantId, request.ImportParameters.Currency);

        //todo: Сделать валидацию вообще таблицы, могут быть траблы с данными + обсудить с ребятами

        await _apiClient.NotificationStartImportAsync(
            new NotificationStartImportRequest(registry.Id, registry.RegistryType.ToString(), registry.RegistryName,
                registry.MerchantId, registry.Currency.ToString(), request.MemberId.Value), cancellationToken);

        try
        {
            var elements = await _cardRegistryParser.Parse(request.ImportParameters.Registry);
            registry.Elements = elements.ToList();
            
            await _apiClient.NotificationSuccessImportAsync(
                new NotificationSuccessImportRequest(registry.Id, registry.Elements.Count), cancellationToken);
        }
        catch (Exception e)
        {
            await _apiClient.NotificationErrorImportAsync(new NotificationErrorImportRequest(registry.Id),
                cancellationToken);
            
            return new ImportError();
        }

        await _registryMongoService.CreateAsync(registry);

        foreach (var element in registry.Elements)
        {
            var paymentType = new PaymentType(element, "PaymentTypeCard", RegistryTypeEnum.Card);
            _successImportProducer.Publish(new SuccessImportElementEvent(registry.Id, paymentType));
        }
        
        return new ImportResponse(registry.Id, registry.Elements.Count);
    }
}