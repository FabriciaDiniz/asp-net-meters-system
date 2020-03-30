using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using LandisWebApp.Hubs;

namespace ProjetoLandisWeb.Controllers
{
    [Route("testhub/[controller]")]
    [ApiController]
    public class ConnectionController : Controller
    {
        IHubContext<TestHub> _hubContext;

        public ConnectionController(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //GET api/connection
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/connection/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //POST api/connection
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _hubContext.Clients.All.SendAsync("Posted", value);
        }

        //PUT api/connection/5
        [HttpPut("{id}")]
        public void Put(int id) { }

        //DELETE api/connection/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}