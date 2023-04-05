using ExchangeRate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExchangeRate.Controllers
{
    public class HomeController : Controller
    {
        private ExchangeResponse _ratesList;

        public HomeController()
        {
            _ratesList = new();
        }

        public async Task<IActionResult> Index()
        {
            await GetRatesListAsync();
            return View(_ratesList);
        }

        public async Task GetRatesListAsync()
        {
            HttpClient Client = new() { BaseAddress = new Uri("https://open.er-api.com/v6/latest/USD") };
            var todos = await Client.GetFromJsonAsync<Dictionary<string,object>>("");
            _ratesList.RatesList = JsonSerializer.Deserialize<Dictionary<string, double>>(todos["rates"].ToString());
        }
    }
}