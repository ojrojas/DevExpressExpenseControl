namespace DevExpressExpenseControl.Services.ExpenseControlApi.Apis;

public static class BudgetEndpoints
{
     public static RouteGroupBuilder MapBudgetEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup("api/budgets").HasApiVersion(1.0).WithTags("BudgetEnpoints");

        api.MapPost("/", CreateBudget).RequireAuthorization();
        api.MapGet("/", ListAllBudget).RequireAuthorization();
        api.MapPatch("/{id:guid}", UpdateBudget).RequireAuthorization();
        api.MapDelete("/{id:guid}", DeleteBudget).RequireAuthorization();
        api.MapMethods("/", [HttpMethods.Options], ShowOptions);

        return api;
    }

    private static async ValueTask<Results<Ok<ListBudgetResponse>, BadRequest<string>, ProblemHttpResult>> ListAllBudget(
        [FromServices] IBudgetService service, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.ListBudgetListAsync(new(), cancellationToken));
    }

    private static async ValueTask<Results<Ok<DeleteBudgetResponse>, BadRequest<string>, ProblemHttpResult>> DeleteBudget(
        [FromServices] IBudgetService service, [FromRoute] Guid id , CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.DeleteBudgetAsync(new(id), cancellationToken));
    }

    private static async ValueTask<Results<Ok<UpdateBudgetResponse>, BadRequest<string>, ProblemHttpResult>> UpdateBudget(
        [FromServices] IBudgetService service, [FromRoute] Guid id, [FromBody] Budget request, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.UpdateBudgetAsync(new (id, request), cancellationToken));
    }

    private static async ValueTask<Results<Ok<CreateBudgetResponse>, BadRequest<string>, ProblemHttpResult>> CreateBudget(
        [FromServices] IBudgetService service, [FromBody] CreateBudgetRequest request, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.CreateBudgetAsync(request, cancellationToken));
    }

    private static async ValueTask<Results<Ok, BadRequest<string>, ProblemHttpResult>> ShowOptions(HttpContext context)
    {
        context.Response.Headers.Append("Allow", "Get, Post, Delete, Patch, Options");
        await Task.CompletedTask;
        return TypedResults.Ok();
    }
}