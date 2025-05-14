namespace DevExpressExpenseControl.Services.Identity.Dtos;

public record DeleteUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}