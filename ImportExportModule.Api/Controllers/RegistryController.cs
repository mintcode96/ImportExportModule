using ImportExportModule.Application.ExcelParses;
using ImportExportModule.DataLayer.Services;
using ImportExportModule.Models.DTO.Requests;
using ImportExportModule.Models.Models;

namespace ImportExportModule.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class RegistryController : Controller
{
    private readonly RegistryMongoService _registryMongoService;
    private readonly IExcelParser _cardRegistryParser;

    public RegistryController(RegistryMongoService registryMongoService, 
        IExcelParser cardRegistryParser)
    {
        _registryMongoService = registryMongoService;
        _cardRegistryParser = cardRegistryParser;
    }

    [HttpPost("ImportRegistry")]
    public async Task<IActionResult> ImportRegistry([FromQuery] ImportRequest importParameters,
        IFormFile importRegistry)
    {
        var elements = await _cardRegistryParser.Parse(importRegistry);
        var registry = new Registry()
        {
            Elements = elements.ToList(),
            Currency = importParameters.Currency,
            MerchantId = importParameters.MerchantId,
            RegistryName = importParameters.Name,
            RegistryType = importParameters.Type
        };

        await _registryMongoService.CreateAsync(registry);

        return Ok();
    }
}