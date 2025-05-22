namespace ExpenseControl.Services.ExpenseControlApi.Services;

public class MovementService(
    ILoggerApplicationService<MovementService> logger,
    ExpenseControlDbContext context
) : IMovementService
{
    readonly ILoggerApplicationService<MovementService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ExpenseControlDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async ValueTask<CreateMovementResponse> CreateMovementAsync(CreateMovementRequest request, CancellationToken cancellationToken)
    {
        CreateMovementResponse response = new(request.CorrelationId());
        var entity = await _context.Movements.AddAsync(request.Movement);
        await _context.SaveChangesAsync(cancellationToken);
        response.MovementCreated = entity.Entity;
        _logger.LogInformation(response, $"Create movement item successful {entity.Entity.MovementType} - amount {entity.Entity.Amount}");
        return response;
    }
}