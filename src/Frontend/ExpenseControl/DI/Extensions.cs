using ExpenseControl.BuildingBlocks.Loggers;
using ExpenseControl.Frontend.ExpenseControl.Services.RequestServices;
using Microsoft.IdentityModel.Logging;
using OpenIddict.Validation.AspNetCore;

namespace ExpenseControl.Frontend.ExpenseControl.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        builder.AddServicesWritersLogger();

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddCascadingAuthenticationState();
        services.AddAuthenticationStateDeserialization();
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