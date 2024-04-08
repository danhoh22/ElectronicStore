using TestOperations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = @"Server=127.0.0.1;Port=5432;Database=ElectronicStore;User Id=postgres;Password=Sosenka2007;";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomerDataAccess>(provider => new CustomerDataAccess(connectionString));
builder.Services.AddScoped<DeliveryOptionAccess>(provider => new DeliveryOptionAccess(connectionString));
builder.Services.AddScoped<OrderAccess>(provider => new OrderAccess(connectionString));
builder.Services.AddScoped<OrderDetailAccess>(provider => new OrderDetailAccess(connectionString));
builder.Services.AddScoped<OrderHistoryAccess>(provider => new OrderHistoryAccess(connectionString));
builder.Services.AddScoped<PaymentAccess>(provider => new PaymentAccess(connectionString));
builder.Services.AddScoped<PricingAccess>(provider => new PricingAccess(connectionString));
builder.Services.AddScoped<ProductAccess>(provider => new ProductAccess(connectionString));
builder.Services.AddScoped<ProductCategoryAccess>(provider => new ProductCategoryAccess(connectionString));
builder.Services.AddScoped<ReviewAccess>(provider => new ReviewAccess(connectionString));
builder.Services.AddScoped<ShoppingCartAccess>(provider => new ShoppingCartAccess(connectionString));
builder.Services.AddScoped<StoreAccess>(provider => new StoreAccess(connectionString));
builder.Services.AddScoped<WarehouseAccess>(provider => new WarehouseAccess(connectionString));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
