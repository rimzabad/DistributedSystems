using DistributedWeatherApplication.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        // Replace "YOUR_API_KEY" with your OpenWeatherMap API key
        string apiKey = "86f3fce50c404680921112037231611";
        string city = "Beirut"; // Replace with the desired city name

        var weatherData = await GetWeatherDataAsync(apiKey, city);

        return View(weatherData);
    }

    private async Task<WeatherData> GetWeatherDataAsync(string apiKey, string city)
    {
        using (var httpClient = _httpClientFactory.CreateClient())
        {
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}";

            try
            {
                var response = await httpClient.GetFromJsonAsync<WeatherData>(apiUrl);
                return response;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }

}
