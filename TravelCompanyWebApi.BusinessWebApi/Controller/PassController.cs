using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class PassController : ControllerBase
    {
        private readonly IPassService _service;

        public PassController(IPassService service)
        {
            _service = service;
        }

        [Route("Passes")]
        [HttpGet]
        public async Task<IActionResult> GetAllPasses()
        {
            var result = await _service.GetAllPasses();

            return Ok(result);
        }

        [Route("Passes")]
        [HttpPost]
        public async Task<IActionResult> PostPass([FromBody] Pass pass)
        {
            await _service.AddPass(pass);

            return Ok();
        }

        [Route("Passes/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePass(int id)
        {
            await _service.DeletePass(id);

            return Ok();
        }

        [Route("Passes/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPassById(int id)
        {
            var result = await _service.GetPassById(id);

            return Ok(result);
        }

        [Route("Passes/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePass(int id, [FromBody] Pass pass)
        {
            await _service.UpdatePass(pass, id);

            return Ok();
        }

        //[Route("Passes/Client/{id}")]
        //[HttpGet]
        //public IActionResult GetPassesByClientId(int id)
        //{
        //    var result = _service.GetPassesByClientId(id);

        //    return Ok(_mapper.Map<IEnumerable<PassOutputDTO>>(result));
        //}

        //[Route("Passes/Tour/{id}")]
        //[HttpGet]
        //public IActionResult GetPassesByTourId(int id)
        //{
        //    var result = _service.GetPassesByTourId(id);

        //    return Ok(_mapper.Map<IEnumerable<PassOutputDTO>>(result));
        //}
    }
}
