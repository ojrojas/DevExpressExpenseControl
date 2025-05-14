namespace DevExpressExpenseControl.Services.ExpenseControlApi.Services;

public class CategoryService(
    ILoggerApplicationService<CategoryService> logger,
    ExpenseControlDbContext context
) : ICategoryService
{
    readonly ILoggerApplicationService<CategoryService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ExpenseControlDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async ValueTask<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        CreateCategoryResponse response = new(request.CorrelationId());
        var entity = await _context.Categories.AddAsync(request.Category);
        await _context.SaveChangesAsync(cancellationToken);
        response.CategoryCreated = entity.Entity;
        _logger.LogInformation(response, $"Create category item successful");
        return response;
    }

    public async ValueTask<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        DeleteCategoryResponse response = new(request.CorrelationId());

        var entity = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        _context.Categories.Remove(entity);
        var result = await _context.SaveChangesAsync(cancellationToken);
        response.CategoryDeleted = result > 0;
        _logger.LogInformation(response, $"Delete category item successful");
        return response;
    }

    public async ValueTask<ListCategoryResponse> ListCategoriesAsync(ListCategoryRequest request, CancellationToken cancellationToken)
    {
         ListCategoryResponse response = new(request.CorrelationId());
        var entities = await _context.Categories.ToListAsync();
        response.Categories = entities;
        _logger.LogInformation(response, $"Get categories items successful");
        return response;
    }

    public async ValueTask<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
         UpdateCategoryResponse response = new(request.CorrelationId());
        var entity = _context.Categories.Update(request.Category);
        await _context.SaveChangesAsync(cancellationToken);
        response.CategoryUpdate = entity.Entity;
        _logger.LogInformation(response, $"Create category item successful");
        return response;
    }
}