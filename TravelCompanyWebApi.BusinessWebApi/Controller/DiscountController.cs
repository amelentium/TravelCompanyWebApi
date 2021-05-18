using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountController(IDiscountService service)
        {
            _service = service;
        }

        [Route("Discounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var result = await _service.GetAllDiscounts();

            return Ok(result);
        }

        [Route("Discounts")]
        [HttpPost]
        public async Task<IActionResult> PostDiscount([FromBody] Discount discount)
        {
            await _service.AddDiscount(discount);

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _service.DeleteDiscount(id);

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var result = await _service.GetDiscountById(id);

            return Ok(result);
        }

        [Route("Discounts/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] Discount discount)
        {
            await _service.UpdateDiscount(discount, id);

            return Ok();
        }
    }
}
