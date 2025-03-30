using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExampleApi.Test;

public class EndpointTestIt : IClassFixture<WebApplicationFactory<Program>>
{
    readonly HttpClient _client;
    public EndpointTestIt(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task WeatherForecastShouldReturnOkResposneAsync()
    {
        var response = await _client.GetAsync("/weatherforecast");
        Assert.Equivalent(response.StatusCode, StatusCodes.Status200OK);

        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);
    }
}