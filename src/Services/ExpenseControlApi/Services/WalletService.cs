namespace DevExpressExpenseControl.Services.ExpenseControlApi.Services;

public class WalletService(
    ILoggerApplicationService<WalletService> logger,
    ExpenseControlDbContext context
) : IWalletService
{
    readonly ILoggerApplicationService<WalletService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ExpenseControlDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async ValueTask<CreateWalletResponse> CreateWalletAsync(CreateWalletRequest request, CancellationToken cancellationToken)
    {
        CreateWalletResponse response = new(request.CorrelationId());
        var entity = await _context.Wallets.AddAsync(request.Wallet);
        await context.SaveChangesAsync(cancellationToken);
        response.WalletCreated = entity.Entity;
        _logger.LogInformation(response, "Create wallet item successful");
        return response;
    }

    public async ValueTask<DesactivedWalletResponse> DesactivedWalletAsync(DesactivedWalletRequest request, CancellationToken cancellationToken)
    {
        DesactivedWalletResponse response = new(request.CorrelationId());
        var entity = await _context.Wallets.FindAsync(new object[] { request.Id }, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        entity.State = false;
        var result = _context.Wallets.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        response.DeactivedWallet = result.Entity.State;
        _logger.LogInformation(response, "Deactive wallet item successful");
        return response;
    }

    public async ValueTask<GetWalletByUserIdResponse> GetWalletByUserIdAsync(GetWalletByUserIdRequest request, CancellationToken cancellationToken)
    {
        GetWalletByUserIdResponse response = new(request.CorrelationId());
        var entity = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId.Equals(request.Id));
        ArgumentNullException.ThrowIfNull(entity);
        response.Wallet = entity;
        _logger.LogInformation(response, "Get wallet by user id item successful");
        return response;
    }

    public async ValueTask<UpdateWalletResponse> UpdateWalletAsync(UpdateWalletRequest request, CancellationToken cancellationToken)
    {
        UpdateWalletResponse response = new(request.CorrelationId());
        var entity = await _context.Wallets.FindAsync(new object[] { request.Id }, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        entity.Name = request.Wallet.Name;
        entity.State = request.Wallet.State;
        var result = _context.Wallets.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        response.WalletUpdated = result.Entity;
        _logger.LogInformation(response, "Deactive wallet item successful");
        return response;
    }
}