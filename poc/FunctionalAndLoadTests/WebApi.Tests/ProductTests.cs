using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace WebApi.Tests;

public class ProductTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetProducts_ReturnsSuccessAndList()
    {
        var response = await _client.GetAsync("/api/products");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        products.Should().NotBeNull();
        products.Should().HaveCountGreaterThan(0);
    }
}
