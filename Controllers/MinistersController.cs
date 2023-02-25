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
    }
} 