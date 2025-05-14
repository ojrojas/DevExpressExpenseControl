namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateMovementResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Movement MovementCreated { get; set; }
}