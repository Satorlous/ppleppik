using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_Core3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private AppContext ctx;
        public ServiceController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        // GET: api/service/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var service = ctx.Services
                .Include(s => s.ServiceRequest)
                .FirstOrDefault(x=>x.Id == id);
            return Ok(service);
        }

        // POST: api/service
        [HttpPost]
        public IActionResult Post(Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            ctx.Services.Add(new Service()
            {
                Name = service.Name,
                Price = service.Price,
                ServiceRequest = service.ServiceRequest
            });
            ctx.SaveChanges();

            return Ok();
        }

        // PUT: api/service/
        [HttpPut]
        public IActionResult Put(Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingService = ctx.Services.Find(service.Id);
            if (existingService != null)
            {
                existingService.Name = service.Name;
                existingService.Price = service.Price;
                ctx.SaveChanges();
            }
            else
                return NotFound();

            return Ok();
        }

        // DELETE: api/service/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var existingService = ctx.Services.Find(id);
            if (existingService != null)
            {
                ctx.Remove(existingService);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}