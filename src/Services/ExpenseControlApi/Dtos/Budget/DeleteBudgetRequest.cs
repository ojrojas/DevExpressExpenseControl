namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record DeleteBudgetRequest(Guid Id) : BaseRequest
{
}