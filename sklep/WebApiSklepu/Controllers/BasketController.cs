using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSklepu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basket;

        public BasketController(IBasketService basket)
        {
            this.basket = basket;
        }

        // GET: api/<BasketController>
        [HttpGet]
        public IEnumerable<BasketItemDto> Get()
        {
            return basket.Get();
        }

        // GET api/<BasketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BasketController>
        [HttpPost("{id}")]
        public IEnumerable<BasketItemDto> Post(int id, [FromBody] double count)
        {
            return basket.Post(id, count);
        }

        // PUT api/<BasketController>/5
        [HttpPut("{id}")]
        public IEnumerable<BasketItemDto> Put([FromQuery] int basketItemId, [FromQuery] double count)
        {
            return basket.Put(basketItemId, count);
        }

        // DELETE api/<BasketController>/5
        [HttpDelete("{id}")]
        public IEnumerable<BasketItemDto> Delete(int id)
        {
            return basket.Delete(id);
        }
    }
}
