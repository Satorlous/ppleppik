using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServiceReference;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        ApiServiceClient service = new ApiServiceClient();
        [HttpGet]
        public string Get()
        {
            var response = service.GetResponseAsync().Result;
            var sentence = JsonSerializer.Deserialize<Dictionary<string, string>>(response).First().Value;
            return sentence.Replace(' ', '_');
        }
    }
}
