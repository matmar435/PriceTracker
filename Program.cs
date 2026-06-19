using Microsoft.EntityFrameworkCore;
using Product_Price_Tracker.Data;
using Product_Price_Tracker.Provider;
using Product_Price_Tracker.Provider.Interfaces;
using Product_Price_Tracker.Services;
using Product_Price_Tracker.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPriceProvider, MockPriceProvider>();
builder.Services.AddScoped<IPriceScraperService, PriceScraperService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
