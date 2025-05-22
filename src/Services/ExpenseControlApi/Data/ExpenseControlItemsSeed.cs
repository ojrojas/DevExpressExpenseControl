namespace ExpenseControl.Services.ExpenseControlApi.Data;

public static class ExpenseControlItemsSeed
{
    public static IEnumerable<Wallet> GetWallets()
    {
        Guid WALLET1_ID = Guid.Parse("27D287F6-B6B3-4199-256F-08DD92969DDD");
        Guid USER_APPLICATION_ID = Guid.Parse("cd2878b8-e73a-4a92-beff-8d26a31d784a");
        var wallet1 = new Wallet
        {
            Id = WALLET1_ID,
            Name = "Wallet Pepe",
            UserId = USER_APPLICATION_ID,
            CreatedBy = USER_APPLICATION_ID
        };

        return [wallet1];
    }

    public static IEnumerable<Category> GetCategories()
    {
        var Category1 = new Category
        {
            Name = "Spent",
            MovementType = MovementType.EXPENSE
        };

        var Category2 = new Category
        {
            Name = "Saving",
            MovementType = MovementType.INCOME
        };

        return [Category1, Category2];
    }
}