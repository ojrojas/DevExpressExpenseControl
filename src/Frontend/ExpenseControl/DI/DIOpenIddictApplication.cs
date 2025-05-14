using Microsoft.IdentityModel.Tokens;

namespace DevExpressExpenseControl.Frontend.ExpenseControl.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.ClientId = "expensecontrol_web";
            options.ProviderOptions.Authority = $"{configuration["Identity:Url"]}/";
            options.ProviderOptions.ResponseType = "code";

            // Note: response_mode=fragment is the best option for a SPA. Unfortunately, the Blazor WASM
            // authentication stack is impacted by a bug that prevents it from correctly extracting
            // authorization error responses (e.g error=access_denied responses) from the URL fragment.
            // For more information about this bug, visit https://github.com/dotnet/aspnetcore/issues/28344.
            //
            options.ProviderOptions.ResponseMode = "query";

            // Add the "roles" (OpenIddictConstants.Scopes.Roles) scope and the "role" (OpenIddictConstants.Claims.Role) claim
            // (the same ones used in the Startup class of the Server) in order for the roles to be validated.
            // See the Counter component for an example of how to use the Authorize attribute with roles
            options.ProviderOptions.DefaultScopes.Add("roles");
            options.UserOptions.RoleClaim = "role";
        });

        return services;
    }
}