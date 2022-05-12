using BikeShop.Data;
using BikeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BikeShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        IBikeLogic logic;

        public BikeController(IBikeLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BikeController>
        [HttpGet]
        public IEnumerable<Bike> GetAll()
        {
            return this.logic.GetAlll();
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public Bike GetOneReal(int id)
        {
            return this.logic.GetOne2(id);
        }

        // POST api/<BikeController>
        [HttpPost]
        public void Add([FromBody] Bike bike)
        {
            this.logic.AddBike2(bike);
        }

        // PUT api/<BikeController>/5
        [HttpPut]
        public void Update([FromBody] Bike value)
        {
            this.logic.ChangeName(value.Id, value.Model);
            this.logic.ChangePrice(value.Id, (int)value.BasePrice);
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteBike(id);
        }
    }
}
