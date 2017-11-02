using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        readonly ApiContext context;

        public MessagesController(ApiContext context) {
            this.context = context;
        }

        public IEnumerable<Models.Message> Get() {
            return context.messages;
        }
        [HttpGet("{name}")]
        public IEnumerable<Models.Message> Get(string name) {
            return context.messages.Where(message => message.Owner == name);
        }

        [HttpPost]
        public Models.Message Post([FromBody] Models.Message message) {
            var DbMessage = context.messages.Add(message).Entity;
            context.SaveChanges();
            return DbMessage;
        }
    }
}
