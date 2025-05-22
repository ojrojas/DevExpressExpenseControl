
using ExpenseControl.BuildingBlocks.Entities;

namespace ExpenseControl.Frontend.ExpenseControl.Models;

public class Budget : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public decimal BudgetAmount { get; set; }
}