namespace ExpenseControl.Services.ExpenseControlApi.Models;


public class Movement : BaseEntity
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public required MovementType MovementType { get; set; }
    public Wallet Wallet { get; set; }
    public Guid WalletId { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }

}