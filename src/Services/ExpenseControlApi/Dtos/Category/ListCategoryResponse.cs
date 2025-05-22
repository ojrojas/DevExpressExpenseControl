namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record ListCategoryResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public IEnumerable<Category> Categories{ get; set; }
}