using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ministers_of_sweden.web.ViewModels;

namespace ministers_of_sweden.web.Controllers
{
    public class MinistersController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;

        public MinistersController(IConfiguration config, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = config.GetSection("apiSettings:baseUrl").Value;
            _options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        }

        // MINISTER LIST
       [HttpGet("list")]
       public async Task<IActionResult> Index()
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        var ministers = JsonSerializer.Deserialize<IList<IndexViewModel>>(json, _options);

        return View ("Index", ministers);


        // MINSITER DETAILS
    }   
       [HttpGet("details/{id}")]
       public async Task<IActionResult> Details (int id)
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers/{id}");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        var minister = JsonSerializer.Deserialize<MinisterDetailModel>(json, _options);
        return View ("Details", minister);
    }
        //MINISTER DELETE

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete (int id)
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers/delete/{id}");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        return RedirectToAction(nameof(Index));
        
    }

    
    }
  
}