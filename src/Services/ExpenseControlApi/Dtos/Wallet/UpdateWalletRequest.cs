namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record UpdateWalletRequest(Guid Id, Wallet Wallet) : BaseRequest
{
}