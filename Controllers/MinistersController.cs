using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ministers_of_sweden.web.ViewModels;
using Newtonsoft.Json;

namespace ministers_of_sweden.web.Controllers
{
    [Route("Ministers")]
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

        // MINISTER LIST (WORKS)
       [HttpGet("list")]
       public async Task<IActionResult> Index()
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        var ministers = System.Text.Json.JsonSerializer.Deserialize<IList<IndexViewModel>>(json, _options);
        

        return View ("Index", ministers);


        // MINSITER DETAILS (WORKS)
    }   
       [HttpGet("details/{id}")]
       public async Task<IActionResult> Details (int id)
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.GetAsync($"{_baseUrl}/ministers/{id}");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        var minister = System.Text.Json.JsonSerializer.Deserialize<MinisterDetailModel>(json, _options);
        return View ("Details", minister);
    }
        //MINISTER DELETE (WORKS)

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete (int id)
    {
        using var client = _httpClient.CreateClient();
        //Nu kan vi göra ett anrop över internet
        var response = await client.DeleteAsync($"{_baseUrl}/ministers/delete/{id}");

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        return RedirectToAction(nameof(Index));
        
    }

    // MINISTER CREATE (WORKS)
    [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            
     using var client = _httpClient.CreateClient();
     

     //Get Party list
     var responseParty = await client.GetAsync($"{_baseUrl}/parties");
       if(!responseParty.IsSuccessStatusCode) return Content("It went wrong");

       var jsonP = await responseParty.Content.ReadAsStringAsync();

        var parties = System.Text.Json.JsonSerializer.Deserialize<IList<PartyViewModel>>(jsonP, _options);
        
        var partiesList = new List<SelectListItem>();
        foreach (var party in parties)
        {
        partiesList.Add(new SelectListItem { Value = party.Name, Text = party.Name});   
        }

    //Get Deparment list
    var responseDepartment = await client.GetAsync($"{_baseUrl}/departments");
     if(!responseDepartment.IsSuccessStatusCode) return Content("It went wrong");

    var jsonD = await responseDepartment.Content.ReadAsStringAsync();
    var departments = System.Text.Json.JsonSerializer.Deserialize<IList<DepartmentViewModel>>(jsonD, _options);

     var departmentsList = new List<SelectListItem>();
        foreach (var department in departments)
        {
        departmentsList.Add(new SelectListItem { Value = department.Name, Text = department.Name});   
        }
    //Get Academic Field List
    var responseAcademicField = await client.GetAsync($"{_baseUrl}/academicfields");
     if(!responseParty.IsSuccessStatusCode) return Content("It went wrong");

     var jsonA = await responseAcademicField.Content.ReadAsStringAsync();
    var academicFields = System.Text.Json.JsonSerializer.Deserialize<IList<AcademicFieldViewModel>>(jsonA, _options);

     var academicFieldsList = new List<SelectListItem>();
        foreach (var academicField in academicFields)
        {
        academicFieldsList.Add(new SelectListItem { Value = academicField.Name, Text = academicField.Name});   
        }

       
       var ministers = new MinisterPostViewModel();
        ministers.Parties = partiesList;
        ministers.Departments = departmentsList;
        ministers.AcademicFields = academicFieldsList;

     
        return View ("Create", ministers);
        }
    
    [HttpPost("Create")]
        public async Task<IActionResult> Create (MinisterPostViewModel minister)
        {
        using var client = _httpClient.CreateClient();
     
     //Need to get the lists again for dropdown to work in Post!

     //Get Party list
     var responseParty = await client.GetAsync($"{_baseUrl}/parties");
       if(!responseParty.IsSuccessStatusCode) return Content("It went wrong");

       var jsonP = await responseParty.Content.ReadAsStringAsync();

        var parties = System.Text.Json.JsonSerializer.Deserialize<IList<PartyViewModel>>(jsonP, _options);
        
        var partiesList = new List<SelectListItem>();
        foreach (var party in parties)
        {
        partiesList.Add(new SelectListItem { Value = party.Name, Text = party.Name});   
        }

    //Get Deparment list
    var responseDepartment = await client.GetAsync($"{_baseUrl}/departments");
     if(!responseDepartment.IsSuccessStatusCode) return Content("It went wrong");

    var jsonD = await responseDepartment.Content.ReadAsStringAsync();
    var departments = System.Text.Json.JsonSerializer.Deserialize<IList<DepartmentViewModel>>(jsonD, _options);

     var departmentsList = new List<SelectListItem>();
        foreach (var department in departments)
        {
        departmentsList.Add(new SelectListItem { Value = department.Name, Text = department.Name});   
        }
    //Get Academic Field List
    var responseAcademicField = await client.GetAsync($"{_baseUrl}/academicfields");
     if(!responseParty.IsSuccessStatusCode) return Content("It went wrong");

     var jsonA = await responseAcademicField.Content.ReadAsStringAsync();
    var academicFields = System.Text.Json.JsonSerializer.Deserialize<IList<AcademicFieldViewModel>>(jsonA, _options);

     var academicFieldsList = new List<SelectListItem>();
        foreach (var academicField in academicFields)
        {
        academicFieldsList.Add(new SelectListItem { Value = academicField.Name, Text = academicField.Name});   
        }

       
      
        minister.Parties = partiesList;
        minister.Departments = departmentsList;
        minister.AcademicFields = academicFieldsList;
       

          
        if (!ModelState.IsValid) return View("create", minister);
    
       // using var client = _httpClient.CreateClient();

        //Serialize to JSON
        var myContent = JsonConvert.SerializeObject(minister);

        //Construct a content object to send this data. Using ByteArrayContent
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);

        //Set the content type to let the API know it is JSON
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //Send request with HTTPContent type
        var response = await client.PostAsync($"{_baseUrl}/ministers", byteContent);

        if(!response.IsSuccessStatusCode) return Content("It went wrong");

        var json = await response.Content.ReadAsStringAsync();

        return RedirectToAction(nameof(Index)); 
    
    }
  
}}