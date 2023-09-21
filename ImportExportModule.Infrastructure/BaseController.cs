using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Np.Extensions.Result;
using Np.MemberAuthorizationIncoming.JWT;

namespace ImportExportModule.Infrastructure;

/// <summary>
/// Базовый класс контролеров с атрибутов авторизации
/// </summary>
//[Authorize]
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Медиатор
    /// </summary>
    protected readonly IMediator Mediator;
    
    private Guid _memberId;

    /// <inheritdoc />
    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    /// <summary>
    /// <see cref="ControllerBase.NotFound()"/>
    /// </summary>
    protected NotFoundObjectResult NotFound(ErrorResponse response) =>
        NotFound(response.ToProblemDetails(StatusCodes.Status404NotFound));

    /// <summary>
    /// <see cref="ControllerBase.BadRequest()"/>
    /// </summary>
    protected BadRequestObjectResult BadRequest(ErrorResponse response) =>
        BadRequest(response.ToProblemDetails(StatusCodes.Status400BadRequest));

    /// <summary>
    /// Сервис не доступен
    /// </summary>
    protected NotFoundObjectResult Unavailable(ErrorResponse response) =>
        NotFound(response.ToProblemDetails(StatusCodes.Status503ServiceUnavailable));
    
    /// <summary>
    /// Идентификатор сервиса пославшего запрос
    /// </summary>
    protected Guid? MemberId
    {
        get
        {
            if (_memberId != default)
                return _memberId;
            
            var tryParse = Guid.TryParse(Request.GetJwtValue("nameid"), out var result);
            _memberId = result;
            
            return tryParse ? result : null;
        }
    }
}