namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record DeleteBudgetResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public bool DeletedBudget { get; set; }
}