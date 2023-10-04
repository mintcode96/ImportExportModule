using System.Reflection;
using ImportExportModule.Application.ApiClients;
using ImportExportModule.Application.Commands.ImportRegistry;
using ImportExportModule.Application.ExcelParses;
using ImportExportModule.Application.Rabbit;
using ImportExportModule.Application.Rabbit.Events;
using ImportExportModule.Application.Rabbit.Producers;
using ImportExportModule.DataLayer.Services;
using ImportExportModule.Models.Configurations;
using Microsoft.Extensions.Options;
using Np.Extensions.DependencyInjection;
using Np.Extensions.Metrics;
using Np.Extensions.Metrics.Settings;
using Np.MediatR;
using Np.MemberAuthorizationIncoming.Settings;
using Np.RabbitMQ;
using Np.RabbitMQ.Settings;
using Np.Service.Report;
using Np.Service.Report.Models;
using Np.Service.Telegram;
using Np.Service.Telegram.Models;
using RabbitMQ.Client;
using Serilog;
using Constants = Serilog.Core.Constants;

namespace ImportExportModule.Api.Configuration;

/// <summary>
/// Конфигурация services
/// </summary>
public static class ServiceCollectionExtensions
{
    private static readonly Serilog.ILogger Logger =
        Log.Logger.ForContext(Constants.SourceContextPropertyName, nameof(ServiceCollectionExtensions));
    
    /// <summary>
    /// ConfigureApplicationServices
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(TimingsBehavior<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
 
        services.AddSingleton<ITelegramService, TelegramService>();
        services.AddSingleton<IReportService, ReportService>();
        services.AddSingleton<IServiceApiClient, ServiceApiClient>();
        
        services.AddSingleton<RegistryMongoService>();
        services.AddTransient<IExcelParser, CardRegistryParser>();

        var assemblies = new[]
        {
            // Explicit assemblies enumeration: AppDomain.CurrentDomain.GetAssemblies()
            // doesn't show all assemblies as loaded in memory during startup
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(ImportRegistryCommand)), 
        };

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
    }
    
    /// <summary>
    /// ConfigureRabbitMqServices
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureRabbitMqServices(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqProducer<SuccessImportElementEvent>, SuccessImportProducer>();
        
        services.AddSingleton(serviceProvider =>
        {
            var rabbitSettings = serviceProvider.GetRequiredService<IOptions<RabbitMqSettings>>().Value;
            var uri = new Uri(
                $"{rabbitSettings.Protocol}://{rabbitSettings.UserName}:{rabbitSettings.Password}" +
                $"@{rabbitSettings.Host}:{rabbitSettings.Port}/{rabbitSettings.VirtualHost}");
            return new ConnectionFactory
            {
                Uri = uri
            };
        });
    }

    /// <summary>
    /// ConfigureHttpClients
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var metricsSettings = serviceProvider.GetRequiredService<IOptions<MetricsSettings>>().Value;

        MetricsExtensions.CreateCollector(Logger, metricsSettings);

        services.AddHttpClient();
    }

    /// <summary>
    /// Configure классов настроек
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureSettings<TelegramSettings>(config, nameof(TelegramSettings));
        services.ConfigureSettings<ReportsServiceSettings>(config, nameof(ReportsServiceSettings));
        services.ConfigureSettings<MetricsSettings>(config, nameof(MetricsSettings));
        services.ConfigureSettings<JwtOptions>(config, nameof(JwtOptions));
        
        services.ConfigureSettings<RegistriesAndApplicationSettings>(config, nameof(RegistriesAndApplicationSettings));
        
        services.ConfigureSettings<SuccessImportProducerSettings>(config, nameof(SuccessImportProducerSettings));
        services.ConfigureSettings<RabbitMqSettings>(config, nameof(RabbitMqSettings));
    }
}
