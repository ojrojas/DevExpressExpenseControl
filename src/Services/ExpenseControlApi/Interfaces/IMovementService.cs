namespace ExpenseControl.Services.ExpenseControlApi.Interfaces;

public interface IMovementService 
{
    ValueTask<CreateMovementResponse> CreateMovementAsync(CreateMovementRequest request, CancellationToken cancellationToken);
}