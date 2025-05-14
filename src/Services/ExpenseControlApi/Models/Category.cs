namespace DevExpressExpenseControl.Services.ExpenseControlApi.Models;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required MovementType MovementType { get; set; }
    public ICollection<Movement> Movements { get; set; }
    public ICollection<Budget> Budgets { get; set; }
}