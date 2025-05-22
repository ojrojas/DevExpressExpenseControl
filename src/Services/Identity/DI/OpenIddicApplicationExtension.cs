namespace ExpenseControl.Services.Identity.DI;

internal static class OpenIddicApplicationExtension
{
    public static IServiceCollection AddOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict()
        .AddCore(config =>
        {
            config.UseEntityFrameworkCore()
            .UseDbContext<IdentityAppDbContext>();
            config.UseQuartz();
        })

        .AddServer(config =>
        {
            config.AllowPasswordFlow();
            config.AllowClientCredentialsFlow();
            config.AllowAuthorizationCodeFlow();
            config.AllowImplicitFlow();
            config.AllowRefreshTokenFlow();

            config.RequireProofKeyForCodeExchange();

            config.SetAuthorizationEndpointUris("/connect/authorize");
            config.SetIntrospectionEndpointUris("/connect/introspect");
            config.SetTokenEndpointUris("/connect/token");
            config.SetEndSessionEndpointUris("/connect/logout");


            config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));
            
            config.AddDevelopmentEncryptionCertificate();
            config.AddDevelopmentSigningCertificate();

            config.UseAspNetCore()
              .DisableTransportSecurityRequirement()
              .EnableAuthorizationEndpointPassthrough()
              .EnableEndSessionEndpointPassthrough()
              .EnableTokenEndpointPassthrough();
        })

        .AddValidation(config =>
        {
            config.UseLocalServer();
            config.UseAspNetCore();
        });

        return services;
    }
}