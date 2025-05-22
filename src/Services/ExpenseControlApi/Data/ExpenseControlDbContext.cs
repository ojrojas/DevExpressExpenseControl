namespace ExpenseControl.Services.ExpenseControlApi.Data;

public class ExpenseControlDbContext : DbContext
{
    public ExpenseControlDbContext(DbContextOptions<ExpenseControlDbContext> options) : base(options) { }
    
    public DbSet<Budget> Budgets{ get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Movement> Movements { get; set; }
    public DbSet<Wallet> Wallets { get; set; }


    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}