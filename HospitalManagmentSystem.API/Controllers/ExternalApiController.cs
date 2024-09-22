
using HospitalManagmentSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExternalApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public ActionResult GetAllPosts() 
        {
            var response = _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;
            var data = JsonSerializer.Deserialize<List<Post>>(response);
            return Ok(data);
        }
    }
}
