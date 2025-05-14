namespace DevExpressExpenseControl.Services.ExpenseControlApi.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer($"{configuration["Identity:Url"]}/");
                config.AddAudiences("expensecontrol_api");

                config.UseIntrospection()
                .SetClientId("expensecontrol_api")
                .SetClientSecret("a2344152-e928-49e7-bb3c-ee54acc96c8c");

                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

                // Register the System.Net.Http integration.
                config.UseSystemNetHttp();

                // Register the ASP.NET Core host.
                config.UseAspNetCore();
            });

        return services;
    }
}