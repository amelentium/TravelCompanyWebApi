using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _service;

        public TourController(ITourService service)
        {
            _service = service;
        }

        [Route("Tours")]
        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            var result = await _service.GetAllTours();

            return Ok(result);
        }

        [Route("Tours")]
        [HttpPost]
        public async Task<IActionResult> PostTour([FromBody] Tour tour)
        {
            await _service.AddTour(tour);

            return Ok();
        }

        [Route("Tours/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTour(int id)
        {
            await _service.DeleteTour(id);

            return Ok();
        }

        [Route("Tours/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTourById(int id)
        {
            var result = await _service.GetTourById(id);

            return Ok(result);
        }

        [Route("Tours/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTour(int id, [FromBody] Tour tour)
        {
            await _service.UpdateTour(tour, id);

            return Ok();
        }

        [Route("Tours/Duration/{id}")]
        [HttpGet]
        public IActionResult GetToursByDurationId(byte id)
        {
            var result = _service.GetToursByDurationId(id);

            return Ok(result);
        }

        [Route("Tours/Hotel/{id}")]
        [HttpGet]
        public IActionResult GetToursByHotelId(int id)
        {
            var result = _service.GetToursByHotelId(id);

            return Ok(result);
        }
    }
}
