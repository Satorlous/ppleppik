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
    public class UserController : ControllerBase
    {
        private AppContext ctx;
        public UserController(AppContext ctx)
        {
            this.ctx = ctx;
        }

        // GET: api/user/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var users = ctx.Users.FirstOrDefault(u => u.Id == id);
            return Ok(users);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Post(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            ctx.Users.Add(new User()
            {
                Name = user.Name,
                Phone = user.Phone,
                Requests = user.Requests
            });
            ctx.SaveChanges();

            return Ok();
        }

        // PUT: api/user/
        [HttpPut]
        public IActionResult Put(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingUser = ctx.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                ctx.SaveChanges();
            }
            else
                return NotFound();

            return Ok();
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            var existingUser = ctx.Users.Find(id);
            if (existingUser != null)
            {
                ctx.Remove(existingUser);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}