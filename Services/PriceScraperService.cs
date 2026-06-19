using Product_Price_Tracker.Services.Interfaces;

namespace Product_Price_Tracker.Services
{
    public class PriceScraperService : IPriceScraperService
    {
        public async Task<decimal?> GetPriceAsync(string url)
        {
            await Task.Delay(500);

            return 1999.99m;
        }
    }
}
