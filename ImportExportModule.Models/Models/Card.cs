using ImportExportModule.Models.Interfaces;


namespace ImportExportModule.Models.Models;

public class Card : ElementRegistry
{
    public string CardNumber { get; set; }
    
    public string Name { get; set; }
    
    public string? ExpirationDate { get; set; }
    
    public double Sum { get; set; }
    
    public string ExternalId { get; set; }
}