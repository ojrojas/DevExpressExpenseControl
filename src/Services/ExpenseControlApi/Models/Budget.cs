namespace DevExpressExpenseControl.Services.ExpenseControlApi.Models;
public class Budget : BaseEntity
{
    public Guid UserId { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public decimal BudgetAmount { get; set; }
}