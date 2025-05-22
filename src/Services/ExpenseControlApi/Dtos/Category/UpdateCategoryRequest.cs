namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateCategoryRequest(Guid Id, Category Category) : BaseRequest
{
}