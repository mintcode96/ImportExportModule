using ImportExportModule.Infrastructure;
using ImportExportModule.Models.DTO.Requests;

namespace ImportExportModule.Api.Controllers;

/// <summary>
/// Импорт
/// </summary>
[Route("import")]
public class ImportController : BaseController
{
    /// ctor
    public ImportController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Загрузка реестра
    /// </summary>
    /// <param name="file">excel документ</param>
    /// <param name="request">тело запроса</param>
    /// <param name="useFake">использовать ли фейк результат</param>
    [HttpPost]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<ActionResult> ImportAsync([FromForm] IFormFile file, [FromBody] ImportRequest request, 
        [FromQuery] bool useFake)
    {
        request.MerchantId ??= MemberId;
        
        if (useFake)
            return Accepted();

        throw new NotImplementedException();
    }
}