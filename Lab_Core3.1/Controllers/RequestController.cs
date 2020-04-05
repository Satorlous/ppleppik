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
    public class RequestController : ControllerBase
    {
        private AppContext ctx;
        public RequestController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        // GET: api/request/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var requests = ctx.Requests
                .Include(s => s.ServiceRequest)
                .FirstOrDefault(x => x.Id == id);
            return Ok(requests);
        }

        // POST: api/request
        [HttpPost]
        public IActionResult Post(Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            ctx.Requests.Add(new Request()
            {
                UserId = request.UserId,
                ServiceRequest = request.ServiceRequest
            });
            ctx.SaveChanges();

            return Ok();
        }

        // PUT: api/request/
        [HttpPut]
        public IActionResult Put(Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingReq = ctx.Requests.Find(request.Id);
            if (existingReq != null)
            {
                existingReq.UserId = request.UserId;
                existingReq.ServiceRequest = request.ServiceRequest;
                ctx.SaveChanges();
            }
            else
                return NotFound();

            return Ok();
        }

        // DELETE: api/request/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var existingReq = ctx.Requests.Find(id);
            if (existingReq != null)
            {
                ctx.Remove(existingReq);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}