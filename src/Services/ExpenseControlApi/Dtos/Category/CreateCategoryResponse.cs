namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateCategoryResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Category CategoryCreated { get; set; }
}