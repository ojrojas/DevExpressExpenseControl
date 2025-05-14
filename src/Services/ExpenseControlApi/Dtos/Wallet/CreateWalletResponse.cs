namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record CreateWalletResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Wallet? WalletCreated { get; set; }
}