using System.Reflection;
using ImportExportModule.Application.Commands.ImportRegistry;
using ImportExportModule.Application.ExcelParses;
using ImportExportModule.DataLayer.Services;
using Microsoft.Extensions.Options;
using Np.Extensions.DependencyInjection;
using Np.Extensions.Metrics;
using Np.Extensions.Metrics.Settings;
using Np.MediatR;
using Np.MemberAuthorizationIncoming.Settings;
using Np.Service.Report;
using Np.Service.Report.Models;
using Np.Service.Telegram;
using Np.Service.Telegram.Models;
using Serilog;
using Serilog.Core;

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
    }
}
