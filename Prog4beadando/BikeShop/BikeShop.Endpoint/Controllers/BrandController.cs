using BikeShop.Data;
using BikeShop.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return this.logic.GetAlll();
        }


        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return this.logic.GetOne2(id);
        }


        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            this.logic.AddBrand(value);
        }


        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.logic.ChangeName(value.Id, value.Name);
            this.logic.ChangeCountry(value.Id, value.Country);
            this.logic.ChangeEstablished(value.Id, value.Established);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteBrand(id);
        }

    }
}
