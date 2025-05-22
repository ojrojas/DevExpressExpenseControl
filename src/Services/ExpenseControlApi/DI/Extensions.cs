namespace ExpenseControl.Services.ExpenseControlApi.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        builder.AddServicesWritersLogger();

        builder.AddSqlServerDbContext<ExpenseControlDbContext>("expencecontrolDB");

        builder.EnrichSqlServerDbContext<ExpenseControlDbContext>();

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        IdentityModelEventSource.ShowPII = true;

        services.AddHttpContextAccessor();
        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
        services.AddTransient<IWalletService, WalletService>();
        services.AddTransient<IBudgetService, BudgetService>();
        services.AddTransient<IMovementService, MovementService>();
        services.AddTransient<ICategoryService, CategoryService>();


        services.AddTransient<ExpenseControlSeed>();
    }
}