using System.Data;
using System.Globalization;
using ExcelDataReader;
using ImportExportModule.Models.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ImportExportModule.Application.ExcelParses;

/// <summary>
/// Парсер реестра карт
/// </summary>
public class CardRegistryParser : IExcelParser
{
    /// <inheritdoc/>
    public async Task<IEnumerable<ElementRegistry>> Parse(IFormFile file)
    {
        var result = new List<Card>();

        await using (var stream = file.OpenReadStream())
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            var dataset = reader.AsDataSet(new ExcelDataSetConfiguration() {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration() {
                    UseHeaderRow = true
                }
            });
            
            foreach(DataRow row in dataset.Tables[0].Rows)
            {
                var itemsArray = row.ItemArray;
                
                result.Add(new Card
                {
                    CardNumber = itemsArray[0].ToString(),
                    ExpirationDate = itemsArray[2].ToString(),
                    ExternalId = itemsArray[4].ToString(),
                    Name = itemsArray[1].ToString(),
                    Sum = double.Parse(itemsArray[3].ToString(), CultureInfo.InvariantCulture)
                });
            }
        }

        return result;
    }
}