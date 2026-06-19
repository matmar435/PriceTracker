using Product_Price_Tracker.Provider.Interfaces;

namespace Product_Price_Tracker.Provider
{
    public class MockPriceProvider : IPriceProvider
    {
        private readonly Random _random = new();

        public Task<decimal?> GetCurrentPriceAsync(string url)
        {
            decimal price = _random.Next(1000, 5000);

            return Task.FromResult<decimal?>(price);
        }
    }
}
