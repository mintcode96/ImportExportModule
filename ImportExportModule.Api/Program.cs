using System.Globalization;
using System.Reflection;
using System.Text;
using Hellang.Middleware.ProblemDetails;
using ImportExportModule.Api.Configuration;
using ImportExportModule.Application.ExcelParses;
using ImportExportModule.DataLayer.Services;
using ImportExportModule.Models.Configurations;
using Np.Extensions.Metrics;
using Np.Extensions.Metrics.MediatR;
using Np.Logging.Logger;
using Np.MemberAuthorizationIncoming;
using Np.Swagger;
using Prometheus;

const string appName = "auth-service-api";

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseLogging(Assembly.GetExecutingAssembly().GetName().Name ?? appName,
    (_, _) => { }, configuration:builder.Configuration);

// Add services to the container.
builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDatabase"));
builder.Services.AddControllers();
ProblemDetailsExtensions.AddProblemDetails(builder.Services);
builder.Services.ConfigureTracer(appName);
builder.Services.AddSingleton<MetricReporter>();
builder.Services.AddTransient<HttpOutMetricsHandler>();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureSwagger(appName);
builder.Services.ConfigureHttpClients();
builder.Services.ConfigureJwtBearer();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();


Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var app = builder.Build();

var cultureInfo = new CultureInfo("ru-RU");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseProblemDetails();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseHttpMetrics();
app.UseAuthorization();
app.UseInHttpMetrics();
app.ConfigureAccess();

app.UseSwagger()
    .UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", appName);
    });

app.MapControllers();
app.MapMetrics();
            
app.UseMetricServer();

app.Run();
