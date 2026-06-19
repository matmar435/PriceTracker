using Product_Price_Tracker.Entities;
using Product_Price_Tracker.Provider.Interfaces;

namespace Product_Price_Tracker.BackgroundServices;

public class PriceCheckBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public PriceCheckBackgroundService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var repository =
                scope.ServiceProvider.GetRequiredService<IProductRepository>();

            var priceProvider =
                scope.ServiceProvider.GetRequiredService<IPriceProvider>();

            var products = await repository.GetAllAsync();

            foreach (var product in products)
            {
                var newPrice =
                    await priceProvider.GetCurrentPriceAsync(product.Url);

                if (newPrice is null)
                    continue;

                product.CurrentPrice = newPrice.Value;

                await repository.AddPriceHistoryAsync(
                    new PriceHistory
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        Price = newPrice.Value,
                        CheckedAt = DateTime.UtcNow
                    });
            }

            await repository.SaveChangesAsync();

            await Task.Delay(
                TimeSpan.FromMinutes(1),
                stoppingToken);
        }
    }
}
