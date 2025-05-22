using ExpenseControl.Frontend.ExpenseControl.Services;
using ExpenseControl.Frontend.ExpenseControl.Components;
using ExpenseControl.BuildingBlocks.ServiceDefaults.Extensions;
using ExpenseControl.Frontend.ExpenseControl.DI;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazor(options =>
{
    options.BootstrapVersion = .Blazor.BootstrapVersion.v5;
});

builder.Services.AddRazorPages(config =>
{
    config.Conventions.AuthorizePage("/CreateUser");

    config.Conventions.AuthorizePage("/Category/List");
    config.Conventions.AuthorizePage("/Category/Create");
    config.Conventions.AuthorizePage("/Category/Detail");
    config.Conventions.AuthorizePage("/Category/Edit");

    config.Conventions.AuthorizePage("/Budget/List");
    config.Conventions.AuthorizePage("/Budget/Create");
    config.Conventions.AuthorizePage("/Budget/Detail");
    config.Conventions.AuthorizePage("/Budget/Edit");

});


builder.Services.AddMvc();
builder.Services.AddSingleton<WeatherForecastService>();

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddDIOpenIddictApplication(configuration);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAntiforgery();
app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AllowAnonymous();

app.Run();