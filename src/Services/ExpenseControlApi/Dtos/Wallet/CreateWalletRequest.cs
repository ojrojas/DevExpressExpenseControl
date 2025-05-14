namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateWalletRequest : BaseRequest
{
    public required Wallet Wallet { get; set; }
}