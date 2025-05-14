namespace DevExpressExpenseControl.Services.ExpenseControlApi.Apis;

public static class WalletEnpoints
{
    public static RouteGroupBuilder MapWalletEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup("api/wallets").HasApiVersion(1.0).WithTags("WalletEnpoints");

        api.MapGet("/getwalletbyuserid/{Id:guid}", GetWalletByUserId).RequireAuthorization();
        api.MapPost("/", CreateWallet).RequireAuthorization();
        api.MapPatch("/{Id:guid}", UpdateWallet).RequireAuthorization();
        api.MapDelete("/{Id:guid}", DesactivedWallet).RequireAuthorization();
        api.MapMethods("/", [HttpMethods.Options], ShowOptions);

        return api;
    }

    private static async ValueTask<Results<Ok, BadRequest<string>, ProblemHttpResult>> ShowOptions(HttpContext context)
    {
        context.Response.Headers.Append("Allow", "Get, Post, Delete, Patch, Options");
        await Task.CompletedTask;
        return TypedResults.Ok();
    }

    private static async ValueTask<Results<Ok<DesactivedWalletResponse>, BadRequest<string>, ProblemHttpResult>> DesactivedWallet(
        [FromServices] IWalletService service, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.DesactivedWalletAsync(new(id), cancellationToken));
    }

    private static async ValueTask<Results<Ok<CreateWalletResponse>, BadRequest<string>, ProblemHttpResult>> CreateWallet(
        [FromServices] IWalletService service, [FromBody] CreateWalletRequest request, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.CreateWalletAsync(request, cancellationToken));
    }

    private static async ValueTask<Results<Ok<UpdateWalletResponse>, BadRequest<string>, ProblemHttpResult>> UpdateWallet(
       [FromServices] IWalletService service, [FromRoute] Guid id, [FromBody] Wallet wallet, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.UpdateWalletAsync(new(id, wallet), cancellationToken));
    }

    private static async ValueTask<Results<Ok<GetWalletByUserIdResponse>, BadRequest<string>, ProblemHttpResult>> GetWalletByUserId(
       [FromRoute] Guid id, [FromServices] IWalletService service, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetWalletByUserIdAsync(new(id), cancellationToken));
    }
}