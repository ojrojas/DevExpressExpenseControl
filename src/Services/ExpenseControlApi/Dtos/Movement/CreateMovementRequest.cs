namespace ExpenseControl.Services.ExpenseControlApi.Dtos;


public record CreateMovementRequest: BaseRequest{
    public Movement Movement { get; set; }
}