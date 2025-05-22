namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateBudgetRequest : BaseRequest
{
    public Budget Budget { get; set; }
}