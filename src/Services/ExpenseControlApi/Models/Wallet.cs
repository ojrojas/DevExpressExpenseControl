namespace DevExpressExpenseControl.Services.ExpenseControlApi.Models;

public class Wallet : BaseEntity
{
    public required string Name { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Movement> Movements { get; } = [];
}
