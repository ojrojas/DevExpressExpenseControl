namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateCategoryRequest : BaseRequest
{
    public Category Category { get; set; }
}