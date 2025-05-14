namespace DevExpressExpenseControl.Services.ExpenseControlApi.Apis;

public static class MovementsEndpoints
{
    public static RouteGroupBuilder MapMovementsEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup("api/movements").HasApiVersion(1.0).WithTags("Movements");

        api.MapPost("/", CreateMovements).RequireAuthorization();
        api.MapMethods("/", [HttpMethods.Options], ShowOptions);
        return api;
    }

    private static async ValueTask<Results<Ok, BadRequest<string>, ProblemHttpResult>> ShowOptions(HttpContext context)
    {
        context.Response.Headers.Append("Allow", "Post");
        await Task.CompletedTask;
        return TypedResults.Ok();
    }

    private static async ValueTask<Results<Ok<CreateMovementResponse>, BadRequest<string>, ProblemHttpResult>> CreateMovements(
        [FromBody] CreateMovementRequest request, [FromServices] IMovementService service, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.CreateMovementAsync(request, cancellationToken));
    }
}