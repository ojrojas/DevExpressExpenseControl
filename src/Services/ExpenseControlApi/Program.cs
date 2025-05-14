
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "expenseControlApi", configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDIOpenIddictApplication(configuration);
builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

#if DEBUG
var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

var context = service.GetRequiredService<ExpenseControlDbContext>();
var seed = service.GetRequiredService<ExpenseControlSeed>();

ArgumentNullException.ThrowIfNull(context);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await seed.SeedAsync();

#endif

var expenseControl = app.NewVersionedApi();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

expenseControl.MapMovementsEndpointsV1();
expenseControl.MapWalletEndpointsV1();
expenseControl.MapBudgetEndpointsV1();
expenseControl.MapCategoryEndpointsV1();

app.UseDefaultOpenApi();


app.Run();