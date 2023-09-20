using ImportExportModule.Models.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Application.ExcelParses;

public interface IExcelParser
{
    Task<IEnumerable<ElementRegistry>> Parse(IFormFile file);
}