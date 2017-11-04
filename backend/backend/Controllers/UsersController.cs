using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        readonly ApiContext context;

        public UsersController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id) {
            var user = context.users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult Get() {
            return Ok("secure");
        }
    }
}
