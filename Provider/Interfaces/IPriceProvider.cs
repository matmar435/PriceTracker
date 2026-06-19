namespace Product_Price_Tracker.Provider.Interfaces
{
    public interface IPriceProvider
    {
        Task<decimal?> GetCurrentPriceAsync(string url);
    }
}
