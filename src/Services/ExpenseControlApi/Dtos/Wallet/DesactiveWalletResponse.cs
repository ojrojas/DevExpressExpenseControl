namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record DesactivedWalletResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public bool DeactivedWallet { get; set; }
}