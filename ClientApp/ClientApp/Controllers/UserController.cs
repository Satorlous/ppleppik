using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServiceReference;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServiceClient service = new UserServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.FindAsync(id));

        [HttpPost]
        public IActionResult Post(User user) => Ok(service.CreateAsync(user));
        
        [HttpPut]
        public IActionResult Put(User user) => Ok(service.UpdateAsync(user));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.DeleteAsync(id));
        
    }
}
