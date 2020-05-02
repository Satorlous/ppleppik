using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceServiceReference;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ServiceServiceClient service = new ServiceServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.FindAsync(id));

        [HttpPost]
        public IActionResult Post(Service model) => Ok(service.CreateAsync(model));

        [HttpPut]
        public IActionResult Put(Service model) => Ok(service.UpdateAsync(model));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.DeleteAsync(id));
    }
}