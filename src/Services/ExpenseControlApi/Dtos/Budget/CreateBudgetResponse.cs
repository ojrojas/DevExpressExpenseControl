namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateBudgetResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Budget BudgetCreated { get; set; }
}