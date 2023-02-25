using Microsoft.AspNetCore.Mvc;

namespace ministers_of_sweden.web.Controllers
{
    public class MinistersController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string _baseUrl;

        public MinistersController(IConfiguration config, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = config.GetSection("apiSettings:baseUrl").Value;
        }

          public async Task<IActionResult> Index()
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        
    }   

    }
  
} 