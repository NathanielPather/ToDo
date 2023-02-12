using Microsoft.AspNetCore.Mvc;

namespace ToDo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ToDoListController : ControllerBase
	{
		public ToDoListController()
		{
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("I passed");
		}
	}
}