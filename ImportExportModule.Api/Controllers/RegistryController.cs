using ImportExportModule.Application.Commands.ImportRegistry;
using ImportExportModule.Infrastructure;
using ImportExportModule.Models.DTO.Requests;
using ImportExportModule.Models.DTO.Responses;

namespace ImportExportModule.Api.Controllers;

/// <summary>
/// Контроллер работы с реестрами
/// </summary>
[ApiController]
[Route("[Controller]")]
public class RegistryController : BaseController
{
    public RegistryController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Загрузка реестра
    /// </summary>
    /// <param name="file">excel документ</param>
    /// <param name="importParameters">параметры запроса</param>
    /// <param name="importRegistry">использовать ли фейк результат</param>
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [HttpPost("ImportRegistry")]
    public async Task<ActionResult<ImportResponse>> ImportRegistry([FromQuery] ImportRequest importParameters,
        IFormFile importRegistry)
    {
        importParameters.MerchantId ??= MemberId;

        if (importParameters.UseFake)
            return Accepted();

        var result = await Mediator.Send(new ImportRegistryCommand(importParameters, importRegistry));

        if (result.IsSuccess)
            return result.Data;

        return BadRequest(result.ErrorResponse!);
    }
}