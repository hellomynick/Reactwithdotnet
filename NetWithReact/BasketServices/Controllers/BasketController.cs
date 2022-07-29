using BasketServices.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasketServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BasketOrder), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketOrder>> GetBasketByIdAsync(string id = "1")
        {
            var basket = await _repository.GetBasketAsync(id);

            return Ok(basket ?? new BasketOrder(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketOrder), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketOrder>> UpdateBasketAsync([FromBody] BasketOrder value)
        {
            return Ok(await _repository.UpdateBasket(value));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteBasketByIdAsync(string id)
        {
            await _repository.DeleteBasket(id);
        }
    }
}
