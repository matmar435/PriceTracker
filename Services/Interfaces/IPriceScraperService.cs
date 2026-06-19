namespace Product_Price_Tracker.Services.Interfaces
{
    public interface IPriceScraperService
    {
        Task<decimal?> GetPriceAsync(string url);
    }
}
