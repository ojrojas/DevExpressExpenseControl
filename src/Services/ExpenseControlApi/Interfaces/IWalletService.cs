namespace ExpenseControl.Services.ExpenseControlApi.Interfaces;

public interface IWalletService
{
    ValueTask<CreateWalletResponse> CreateWalletAsync(CreateWalletRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateWalletResponse> UpdateWalletAsync(UpdateWalletRequest request, CancellationToken cancellationToken);
    ValueTask<DesactivedWalletResponse> DesactivedWalletAsync(DesactivedWalletRequest request, CancellationToken cancellationToken);
    ValueTask<GetWalletByUserIdResponse> GetWalletByUserIdAsync(GetWalletByUserIdRequest request, CancellationToken cancellationToken);
}