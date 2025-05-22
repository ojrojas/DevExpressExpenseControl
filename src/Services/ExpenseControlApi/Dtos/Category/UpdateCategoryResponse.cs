namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateCategoryResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Category CategoryUpdate { get; set; }
}