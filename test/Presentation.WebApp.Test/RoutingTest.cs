using Xunit;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentation.WebApp;

namespace Presentation.WebApp.Test
{
    //public class RoutingTest : IClassFixture<WebApplicationFactory<Program>>
    //{
    //    private readonly HttpClient _client;
    //    public RoutingTest(WebApplicationFactory<Program> factory)
    //    {
    //        _client = factory.CreateClient();
    //    }
        
    //    [Theory]
    //    [InlineData("Index")]
    //    [InlineData("Privacy")]
    //    public async Task HomeTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Home/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }

    //    [Theory]
    //    [InlineData("Index")]
    //    [InlineData("Create")]
    //    public async Task ProductosTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Productos/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }

    //    [Theory]
    //    [InlineData("Index")]
    //    [InlineData("Create")]
    //    public async Task PacientesTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Pacientes/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }

    //    [Theory]
    //    [InlineData("Index")]
    //    [InlineData("Create")]
    //    public async Task CitasTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Citas/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }

    //    [Theory]
    //    [InlineData("Index")]
    //    //[InlineData("Create")]
    //    public async Task DoctoresTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Doctores/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }

    //    [Theory]
    //    [InlineData("Index")]
    //    //[InlineData("Create")]
    //    public async Task PagosTestGetPages(string url)
    //    {
    //        // Arrange
    //        // Act
    //        var response = await _client.GetAsync($"/Pagos/{url}");
    //        response.EnsureSuccessStatusCode();
    //        // Assert
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //    }
    //}
}
