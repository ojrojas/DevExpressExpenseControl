using DevExpressExpenseControl.Frontend.ExpenseControl.Services;
using DevExpressExpenseControl.Frontend.ExpenseControl.Components;
using DevExpressExpenseControl.BuildingBlocks.ServiceDefaults.Extensions;
using DevExpressExpenseControl.Frontend.ExpenseControl.DI;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
builder.Services.AddMvc();
builder.Services.AddSingleton<WeatherForecastService>();

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddDIOpenIddictApplication(configuration);

var app = builder.Build();
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AllowAnonymous();

app.Run();