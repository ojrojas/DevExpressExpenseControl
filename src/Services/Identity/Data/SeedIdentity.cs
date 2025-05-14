namespace DevExpressExpenseControl.Services.Identity.Data;

public class SeedIdentity(
    ILoggerApplicationService<SeedIdentity> logger,
    IdentityAppDbContext context,
    UserManager<UserApplication> userManager,
    RoleManager<UserType> roleManager,
    IOpenIddictApplicationManager applicationManager,
    IOpenIddictScopeManager scopeManager,
    IConfiguration configuration)
{
    readonly Guid USER_APPLICATION_ID = Guid.Parse("cd2878b8-e73a-4a92-beff-8d26a31d784a");
    readonly Guid TYPE_IDENTIFICATION_ID = Guid.NewGuid();
    readonly Guid TYPE_USER_ID = Guid.NewGuid();
    readonly Guid CARD_ID = Guid.NewGuid();

    private UserApplication CreateUserApplicationRequest()
    {

        return new UserApplication()
        {
            Id = USER_APPLICATION_ID,
            Name = "Pepe",
            LastName = "Perez",
            IdentificationNumber = "12345679",
            BirthDate = DateTime.UtcNow,
            Address = "CL 1 # 1",
            Contact = "123451234",
            IdentificationType = new()
            {
                Id = TYPE_IDENTIFICATION_ID,
                CreatedBy = USER_APPLICATION_ID,
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "CC",
            },
            IdentificationTypeId = TYPE_IDENTIFICATION_ID,
            UserName = "pepe@example.com",
        };
    }

    private UserType CreateRole()
    {
        return new UserType
        {
            Id = TYPE_USER_ID,
            Name = "Admin",
            NormalizedName = "Admin"
        };
    }

    public async ValueTask SeedAsync()
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        var userApplication = CreateUserApplicationRequest();
        var resultRole = await roleManager.CreateAsync(CreateRole());
        ArgumentNullException.ThrowIfNull(userApplication);
        var exists = await userManager.FindByNameAsync(userApplication.UserName);
        if (exists == null && resultRole.Succeeded)
        {
            userApplication.Email = userApplication.UserName;
            var result = await userManager.CreateAsync(userApplication, "Abc123456#");

            if (result.Succeeded)
            {
                logger.LogInformation("User identity created successful from seed idendity");

                if (resultRole.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Admin");
                    await userManager.AddToRoleAsync(userApplication, role.Name);
                    logger.LogInformation($"Add user to role: {role.Name}");
                }
            }
            else
                logger.LogError("Failed to create identity user");
        }
        else
            logger.LogError("Failed to create identity user");
    }

    public async ValueTask CreateConfigurationOpenIddict()
    {
        if (await applicationManager.FindByClientIdAsync("identity_swagger") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ApplicationType = ApplicationTypes.Web,
                ClientId = "identity_swagger",
                ClientType = ClientTypes.Public,
                DisplayName = "Identity Client Swagger",
                RedirectUris = {
                        new Uri($"{configuration["Identity:Url"]}/swagger/oauth2-redirect.html"),
                        new Uri($"https://oauth.pstmn.io/v1/callback")
                    },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "identity_scope",
                    },
                PostLogoutRedirectUris = {
                    new Uri($"{configuration["Identity:Url"]}/connect/logout"),
                    new Uri($"{configuration["Identity:Url"]}/swagger")
                },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await applicationManager.FindByClientIdAsync("expensecontrol_swagger") is null)
        {
            var route = new Uri($"{configuration["ExpenseControlEndpoint"]}/swagger/oauth2-redirect.html");
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ApplicationType = ApplicationTypes.Web,
                ClientId = "expensecontrol_swagger",
                ClientType = ClientTypes.Public,
                DisplayName = "Expense Control Client Swagger",
                RedirectUris = { new Uri($"{configuration["ExpenseControlEndpoint"]}/swagger/oauth2-redirect.html") },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "expensecontrol_scope"
                    },
                PostLogoutRedirectUris = { new Uri($"{configuration["ExpenseControlEndpoint"]}/swagger/") },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await applicationManager.FindByClientIdAsync("expensecontrol_web") is null)
        {
            var route = new Uri($"{configuration["ExpenseControlEndpoint"]}/swagger/oauth2-redirect.html");
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ApplicationType = ApplicationTypes.Web,
                ClientId = "expensecontrol_web",
                ClientType = ClientTypes.Confidential,
                ClientSecret = "9aa02a96-111b-4385-959b-e7441a202de3",
                DisplayName = "Expense Control Client Web",
                RedirectUris = { new Uri($"{configuration["ExpenseControlWeb"]}/swagger/oauth2-redirect.html") },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "expensecontrol_scope"
                    },
                PostLogoutRedirectUris = { new Uri($"{configuration["Identity:Url"]}/connect/logout") },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await applicationManager.FindByClientIdAsync("notifications_api") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "notifications_api",
                ClientSecret = "9dcc8c2a-7786-4bc8-a8ec-788755226ca0",
                DisplayName = "Notification Client Api",
                Permissions = {
                        Permissions.Endpoints.Introspection,
                    }
            });
        }

        if (await applicationManager.FindByClientIdAsync("expensecontrol_api") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "expensecontrol_api",
                ClientSecret = "a2344152-e928-49e7-bb3c-ee54acc96c8c",
                DisplayName = "Expense Control Client Api",
                Permissions = {
                        Permissions.Endpoints.Introspection,
                    }
            });
        }

        if (await scopeManager.FindByNameAsync("expensecontrol_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "expensecontrol_scope",
                Resources =
                {
                    "expensecontrol_api",
                    "identity_scope"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("identity_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "identity_scope",
                Resources =
                {
                    "resource_server_identity"
                }
            });
        }
    }
}