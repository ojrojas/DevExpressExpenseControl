namespace DevExpressExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateWalletRequest(Guid Id, Wallet Wallet) : BaseRequest
{
}