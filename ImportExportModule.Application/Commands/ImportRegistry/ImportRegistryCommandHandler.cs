using ImportExportModule.Application.ExcelParses;
using ImportExportModule.DataLayer.Services;

namespace ImportExportModule.Application.Commands.ImportRegistry;

/// <summary>
/// 
/// </summary>
public class ImportRegistryCommandHandler : IRequestHandler<ImportRegistryCommand, Result<ImportResponse>>
{
    private readonly RegistryMongoService _registryMongoService;
    private readonly IExcelParser _cardRegistryParser;
    
    public ImportRegistryCommandHandler(RegistryMongoService registryMongoService,
        IExcelParser cardRegistryParser)
    {
        _registryMongoService = registryMongoService;
        _cardRegistryParser = cardRegistryParser;
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

        return new ImportResponse();
    }
}