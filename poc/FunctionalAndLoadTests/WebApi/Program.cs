var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", () =>
{
    List<Product> products =
    [
        new Product(1, "Mouse"),
        new Product(2, "Keyboard"),
        new Product(3, "Monitor")
    ];

    return products;
})
.WithName("GetProducts");

app.Run();

public record Product(int Id, string Name);

// For functional test
public partial class Program {}