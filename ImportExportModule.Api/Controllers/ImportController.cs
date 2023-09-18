using ImportExportModule.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImportExportModule.Api.Controllers;

/// <summary>
/// Импорт
/// </summary>
[Route("import")]
public class ImportController : BaseController
{
    /// ctor
    public ImportController(IMediator mediator) : base(mediator) { }
    
    public async Task<ActionResult> ImportAsync(){}
}