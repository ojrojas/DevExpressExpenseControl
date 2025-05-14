namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateBudgetRequest(Guid Id, Budget Budget) : BaseRequest
{
}