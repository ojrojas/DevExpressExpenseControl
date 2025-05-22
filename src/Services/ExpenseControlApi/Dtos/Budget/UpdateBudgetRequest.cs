namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateBudgetRequest(Guid Id, Budget Budget) : BaseRequest
{
}