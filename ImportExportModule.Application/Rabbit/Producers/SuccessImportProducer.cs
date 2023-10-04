using ImportExportModule.Application.Rabbit.Events;

namespace ImportExportModule.Application.Rabbit.Producers;

/// <summary>
/// Продюссер событий при успешной загрузке реестра
/// </summary>
public class SuccessImportProducer : ProducerBase<SuccessImportElementEvent>
{
    /// <inheritdoc />
    protected override string RoutingKeyName { get; }
    
    /// <inheritdoc />
    protected override string AppId { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public SuccessImportProducer(ConnectionFactory connectionFactory,
        IOptions<RabbitMqSettings> rabbitSettings,
        IOptions<SuccessImportProducerSettings> producerSettings,
        IReportService reportService,
        ILogger logger):
        base(connectionFactory, rabbitSettings.Value, producerSettings.Value, reportService, logger)
    {
        RoutingKeyName = producerSettings.Value.Queue;
        AppId = nameof(SuccessImportProducer);
    }
}