
namespace DevExpressExpenseControl.Services.ExpenseControlApi.Services;

public class BudgetService(
    ILoggerApplicationService<BudgetService> logger,
    ExpenseControlDbContext context
) : IBudgetService
{
    readonly ILoggerApplicationService<BudgetService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ExpenseControlDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async ValueTask<CreateBudgetResponse> CreateBudgetAsync(CreateBudgetRequest request, CancellationToken cancellationToken)
    {
        CreateBudgetResponse response = new(request.CorrelationId());
        var entity = await _context.Budgets.AddAsync(request.Budget);
        await context.SaveChangesAsync(cancellationToken);
        response.BudgetCreated = entity.Entity;
        logger.LogInformation(response, $"Create budget item successful");
        return response;
    }

    public async ValueTask<DeleteBudgetResponse> DeleteBudgetAsync(DeleteBudgetRequest request, CancellationToken cancellationToken)
    {
        DeleteBudgetResponse response = new(request.CorrelationId());
        var entity = await _context.Budgets.FindAsync(new object[] { request.Id }, cancellationToken);
        _context.Remove(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        response.DeletedBudget = result != default;
        logger.LogInformation(response, $"Create category item successful");
        return response;
    }

    public async ValueTask<ListBudgetResponse> ListBudgetListAsync(ListBudgetRequest request, CancellationToken cancellationToken)
    {
        ListBudgetResponse response = new(request.CorrelationId());
        var entities = await _context.Budgets.ToListAsync();
        response.Budgets = entities;
        logger.LogInformation(response, $"Create category item successful");
        return response;
    }

    public async ValueTask<UpdateBudgetResponse> UpdateBudgetAsync(UpdateBudgetRequest request, CancellationToken cancellationToken)
    {
        UpdateBudgetResponse response = new(request.CorrelationId());
        var entity = _context.Budgets.Update(request.Budget);
        await context.SaveChangesAsync(cancellationToken);
        response.BudgetUpdated = entity.Entity;
        logger.LogInformation(response, $"Create category item successful");
        return response;
    }
}