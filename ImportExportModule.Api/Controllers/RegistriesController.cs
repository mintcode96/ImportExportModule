using ImportExportModule.Application.Commands.ImportRegistry;
using ImportExportModule.Infrastructure;
using ImportExportModule.Models.DTO.Requests;
using ImportExportModule.Models.DTO.Responses;

namespace ImportExportModule.Api.Controllers;

/// <summary>
/// Контроллер работы с реестрами
/// </summary>
[ApiController]
[Route("registries")]
public class RegistriesController : BaseController
{
    //ctor
    public RegistriesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Загрузка реестра
    /// </summary>
    /// <param name="request">параметры запроса</param>
    /// <param name="useFake">использовать ли фейковую реализацию</param>
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [HttpPost]
    public async Task<ActionResult<ImportResponse>> Import([FromBody] ImportRequest request, bool useFake)
    {
        request.MerchantId ??= MemberId;

        if (useFake)
            return Accepted();

        var result = await Mediator.Send(new ImportRegistryCommand(request));

        if (result.IsSuccess)
            return result.Data;

        return BadRequest(result.ErrorResponse!);
    }
}