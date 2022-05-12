using BikeShop.Data;
using BikeShop.Endpoint.Services;
using BikeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;

namespace BikeShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerLogic logic;
        IHubContext<SignalRHub> hub;

        public OwnerController(IOwnerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        //GET: api/<ServiceController>
        [HttpGet]
        public IEnumerable<Owner> GetAll()
        {
            return this.logic.GetAlll();
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return this.logic.GetOne2(id);
        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            this.logic.AddOwner(value);
            this.hub.Clients.All.SendAsync("OwnerCreated", value);
        }

        // PUT api/<ServiceController>/5
        [HttpPut]
        public void Update([FromBody] Owner value)
        {
            this.logic.ChangeName(value.Id, value.Name);
            this.logic.ChangeFortune(value.Id, value.Money);
            this.hub.Clients.All.SendAsync("OwnerUpdated", value);
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ownerToDelete = this.logic.GetOne2(id);
            this.logic.DeleteOwner(id);
            this.hub.Clients.All.SendAsync("OwnerDeleted", ownerToDelete);
        }
    }
}
