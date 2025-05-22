namespace ExpenseControl.Services.ExpenseControlApi.Interfaces;


public interface IBudgetService
{
    ValueTask<CreateBudgetResponse> CreateBudgetAsync(CreateBudgetRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateBudgetResponse> UpdateBudgetAsync(UpdateBudgetRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteBudgetResponse> DeleteBudgetAsync(DeleteBudgetRequest request, CancellationToken cancellationToken);
    ValueTask<ListBudgetResponse> ListBudgetListAsync(ListBudgetRequest request, CancellationToken cancellationToken);
}