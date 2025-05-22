namespace ExpenseControl.Services.Identity.Dtos;

public record DeleteUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}