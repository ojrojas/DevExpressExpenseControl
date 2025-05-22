namespace ExpenseControl.Services.ExpenseControlApi.Dtos;

public record GetWalletByUserIdResponse(Guid correlationId): BaseResponse(correlationId)
{
    public Wallet Wallet { get; set; }
}