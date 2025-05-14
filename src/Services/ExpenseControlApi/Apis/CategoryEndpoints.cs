


namespace DevExpressExpenseControl.Services.ExpenseControlApi.Apis;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup("api/categories").HasApiVersion(1.0).WithTags("Categories");

        api.MapPost("/", CreateCategory).RequireAuthorization();
        api.MapPatch("/{id:guid}", UpdateCategory).RequireAuthorization();
        api.MapDelete("/{id:guid}", DeleteCategory).RequireAuthorization();
        api.MapMethods("/", [HttpMethods.Options], ShowOptions);

        return api;
    }

    private static async ValueTask<Results<Ok<DeleteCategoryResponse>, BadRequest<string>, ProblemHttpResult>> DeleteCategory(
        [FromServices] ICategoryService service,[FromRoute] Guid id, CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.DeleteCategoryAsync(new(id), cancellationToken));
    }

    private static async ValueTask<Results<Ok<UpdateCategoryResponse>, BadRequest<string>, ProblemHttpResult>> UpdateCategory(
        [FromServices] ICategoryService service, [FromRoute] Guid id,[FromBody] Category request, CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.UpdateCategoryAsync(new(id, request), cancellationToken));
    }

    private static async ValueTask<Results<Ok<CreateCategoryResponse>, BadRequest<string>, ProblemHttpResult>> CreateCategory(
        [FromServices] ICategoryService service, CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.CreateCategoryAsync(request, cancellationToken));
    }

    private static async ValueTask<Results<Ok, BadRequest<string>, ProblemHttpResult>> ShowOptions(HttpContext context)
    {
        context.Response.Headers.Append("Allow", "Get, Post, Delete, Patch, Options");
        await Task.CompletedTask;
        return TypedResults.Ok();
    }
}