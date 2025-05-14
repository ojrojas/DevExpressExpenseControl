namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateBudgetResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Budget BudgetUpdated { get; set; }
}