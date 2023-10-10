using System.Data;
using System.Globalization;
using ExcelDataReader;
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
            var dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                var itemsArray = row.ItemArray;

                var sum = double.Parse(itemsArray[3].ToString(), CultureInfo.InvariantCulture);

                result.Add(new Card(itemsArray[0].ToString(), itemsArray[1].ToString(), itemsArray[2].ToString(), sum,
                    itemsArray[4].ToString()));
            }
        }

        return result;
    }
}