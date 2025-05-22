using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.BuildingBlocks.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool State { get; set; } = true;
}
