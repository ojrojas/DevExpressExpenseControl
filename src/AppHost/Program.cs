using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
var Identity__Url = "Identity__Url";

var launchProfileName = ShouldUseHttpForEndpoints(configuration) ? "http" : "https";

var mssql = builder.AddSqlServer("expensecontrol-db")
.WithLifetime(ContainerLifetime.Persistent);

var seq = builder.AddSeq("seq");

var IdentityDb = mssql.AddDatabase("identitydb");
var expenceControlDb = mssql.AddDatabase("expencecontrolDB");

var expenceControlWeb = builder.AddProject<Projects.ExpenseControl>("expense-control-web", launchProfileName);
var identityApi = builder.AddProject<Projects.Identity>("expence-control-identity", launchProfileName);
var expenceControlApi = builder.AddProject<Projects.ExpenseControlApi>("expence-control-api", launchProfileName);
var notifications = builder.AddProject<Projects.Notifications>("notifications",launchProfileName);

var identityEndpoint = identityApi.GetEndpoint(launchProfileName);
var expenseControlWebUrl = expenceControlWeb.GetEndpoint(launchProfileName);

expenceControlApi
.WithReference(expenceControlDb)
.WithReference(seq)
.WithEnvironment(Identity__Url, identityEndpoint)
.WaitFor(identityApi);

expenceControlWeb.WithExternalHttpEndpoints()
.WithReference(seq)
.WithReference(expenceControlApi)
.WithEnvironment(Identity__Url, identityEndpoint)
.WithEnvironment("ExpenseControlWeb", expenseControlWebUrl)
.WaitFor(expenceControlApi);

identityApi
.WithReference(IdentityDb)
.WithReference(seq)
.WithReference(expenceControlApi)
.WithReference(expenceControlWeb)
.WithEnvironment(Identity__Url, identityEndpoint)
.WithEnvironment("ExpenseControlEndpoint", expenceControlApi.GetEndpoint(launchProfileName))
.WithEnvironment("ExpenseControlWeb", expenseControlWebUrl)
.WaitFor(IdentityDb);

builder.Build().Run();


static bool ShouldUseHttpForEndpoints(IConfiguration configuration)
{
    var envValue = configuration["EXPENSE_CONTROL_USE_HTTP_ENDPOINTS"];
    return int.TryParse(envValue, out int result) && result == 1;
}