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
    public class ServiceController : ControllerBase
    {
        IServiceLogic logic;
        IHubContext<SignalRHub> hub;

        public ServiceController(IServiceLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        //GET: api/<ServiceController>
        [HttpGet]
        public IEnumerable<Service> GetAll()
        {
            return this.logic.GetAlll();
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public Service Get(int id)
        {
            return this.logic.GetOne2(id);

        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post([FromBody] Service value)
        {
            this.logic.AddServicestation(value);
            this.hub.Clients.All.SendAsync("ServiceCreated", value);
        }

        // PUT api/<ServiceController>/5
        [HttpPut]
        public void Update([FromBody] Service value)
        {
            this.logic.ChangeName(value.Id, value.Name);
            this.logic.ChangeCapacity(value.Id, value.MaxSpace);
            this.logic.ChangeEmpCount(value.Id, value.EmployeeNumer);
            this.hub.Clients.All.SendAsync("ServiceUpdated, value");
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteServicestation(id);
            this.hub.Clients.All.SendAsync("ServiceDeleted", id);
        }
    }
}
