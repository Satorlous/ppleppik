using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestServiceReference;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private RequestServiceClient service = new RequestServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.FindAsync(id));

        [HttpPost]
        public IActionResult Post(Request model) => Ok(service.CreateAsync(model));

        [HttpPut]
        public IActionResult Put(Request model) => Ok(service.UpdateAsync(model));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.DeleteAsync(id));
    }
}