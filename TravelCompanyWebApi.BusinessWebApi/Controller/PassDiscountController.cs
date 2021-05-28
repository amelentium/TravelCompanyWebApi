using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class PassDiscountController : ControllerBase
    {
        private readonly IPassDiscountService _service;

        public PassDiscountController(IPassDiscountService service)
        {
            _service = service;
        }

        [Route("PassDiscounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllPassDiscounts()
        {
            var result = await _service.GetAllPassDiscounts();

            return Ok(result);
        }

        [Route("PassDiscounts")]
        [HttpPost]
        public async Task<IActionResult> PostPassDiscount([FromBody] PassDiscount passDiscount)
        {
            await _service.AddPassDiscount(passDiscount);

            return Ok();
        }

        [Route("PassDiscounts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePassDiscount(int id)
        {
            await _service.DeletePassDiscount(id);

            return Ok();
        }

        [Route("PassDiscounts/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPassDiscountById(int id)
        {
            var result = await _service.GetPassDiscountById(id);

            return Ok(result);
        }

        [Route("PassDiscounts/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePassDiscount(int id, [FromBody] PassDiscount passDiscount)
        {
            await _service.UpdatePassDiscount(passDiscount, id);

            return Ok();
        }

        [Route("PassDiscounts/Discount/{id}")]
        [HttpGet]
        public IActionResult GetPassDiscountsByDiscountId(int id)
        {
            var result = _service.GetPassDiscountsByDiscountId(id);

            return Ok(result);
        }

        [Route("PassDiscounts/Pass/{id}")]
        [HttpGet]
        public IActionResult GetPassDiscountsByPassId(int id)
        {
            var result = _service.GetPassDiscountsByPassId(id);

            return Ok(result);
        }
    }
}
