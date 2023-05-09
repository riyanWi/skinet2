using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace skinet2.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _baksetRepository;
        public BasketController(IBasketRepository baksetRepository)
        {
            _baksetRepository = baksetRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _baksetRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _baksetRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _baksetRepository.DeleteBasketAsync(id);
        }
    }
}