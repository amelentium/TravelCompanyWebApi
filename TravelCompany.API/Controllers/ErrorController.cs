using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TravelCompany.API.Controllers
{
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : ControllerBase
	{
		public ErrorController() { }

		[Route("/error")]
		public IActionResult Error()
		{
			var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

			var details = new ProblemDetails
			{
				Status = StatusCodes.Status400BadRequest,
				Title = exception?.Message ?? "An error occurred while processing your request.",
				Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
				Detail = exception?.ToString()
			};

			return new ObjectResult(details)
			{
				StatusCode = StatusCodes.Status400BadRequest
			};
		}
	}
}
