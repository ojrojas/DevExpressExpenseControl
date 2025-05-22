namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record DeleteCategoryResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public bool CategoryDeleted { get; set; }
}