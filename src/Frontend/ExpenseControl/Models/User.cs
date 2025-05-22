namespace ExpenseControl.Frontend.ExpenseControl.Models;

public class User
{
    public required string Name { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? SurName { get; set; }
    public Guid IdentificationTypeId { get; set; }
    public required string IdentificationNumber { get; set; }
}