using DevExpressExpenseControl.BuildingBlocks.Entities;

namespace DevExpressExpenseControl.Frontend.ExpenseControl.Models;


public class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}