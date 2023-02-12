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
		public IActionResult GetAllToDoLists()
		{
			return Ok("Getting all Lists");
		}

		[HttpGet("GetToDoList/{id}")]
		public IActionResult GetToDoList(int id) {
			return Ok("Getting list");
		}
	}
}