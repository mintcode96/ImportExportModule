using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Application.ExcelParses;

/// <summary>
/// Парсер эксель документов
/// </summary>
public interface IExcelParser
{
    /// <summary>
    /// Парсинг документов excel
    /// </summary>
    Task<IEnumerable<ElementRegistry>> Parse(IFormFile file);
}