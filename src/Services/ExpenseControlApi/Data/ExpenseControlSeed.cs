namespace ExpenseControl.Services.Catalogs.Data;

public class ExpenseControlSeed(ExpenseControlDbContext context)
{
    public async Task SeedAsync()
    {
        await context.Wallets.AddRangeAsync(ExpenseControlItemsSeed.GetWallets());
        await context.Categories.AddRangeAsync(ExpenseControlItemsSeed.GetCategories());
        await context.SaveChangesAsync();
    }
}