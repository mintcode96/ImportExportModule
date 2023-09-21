using ImportExportModule.Application.Commands.ImportRegistry;
using ImportExportModule.Infrastructure;
using ImportExportModule.Models.DTO.Requests;
using ImportExportModule.Models.DTO.Responses;

namespace ImportExportModule.Api.Controllers;

/// <summary>
/// Контроллер работы с реестрами
/// </summary>
[ApiController]
[Route("[Controller]")]// TODO аналогично замечанию ниже, не корректное название, в целом правильно обзывать и давать их максимально явно: "registry" или "registries"
public class RegistryController : BaseController // TODO а чем тебя не устроил ImportController? Он же как раз правильно реализован + соотвественно и ручки там корректные
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
    [HttpPost("ImportRegistry")] // TODO вот я про это место, ручки так не называеются, в данном случае корректнее было бы использовать "import"
    public async Task<ActionResult<ImportResponse>> ImportRegistry([FromQuery] ImportRequest importParameters, // TODO должно присылаться в теле запроса, а не в query
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