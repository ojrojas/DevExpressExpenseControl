using DevExpressExpenseControl.BuildingBlocks.Loggers;
using DevExpressExpenseControl.Frontend.ExpenseControl.Services.RequestServices;
using Microsoft.IdentityModel.Logging;
using OpenIddict.Validation.AspNetCore;

namespace DevExpressExpenseControl.Frontend.ExpenseControl.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        builder.AddServicesWritersLogger();

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        IdentityModelEventSource.ShowPII = true;

        services.AddHttpContextAccessor();
        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));

        services.AddSingleton<IRequestProvider>(sp =>
        {
            var debugHttpHandler = sp.GetKeyedService<HttpMessageHandler>("DebugHttpMessageHandler");
            return new RequestProvider(debugHttpHandler);
        });

    }
}