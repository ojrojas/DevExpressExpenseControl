using ExpenseControl.BuildingBlocks.Entities;

namespace ExpenseControl.Frontend.ExpenseControl.Models;


public class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}