namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateWalletResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public Wallet? WalletUpdated { get; set; }
}