namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record ListBudgetResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public IEnumerable<Budget> Budgets { get; set; }
}