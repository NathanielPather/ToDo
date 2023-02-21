using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Interfaces;

namespace ToDo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ToDoListController : ControllerBase
	{
		private readonly IToDoListService _toDoListService;
		public ToDoListController(IToDoListService toDoListService)
		{
			_toDoListService = toDoListService;
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

		[HttpPost("CreateToDoList")]
		public IActionResult CreateToDoList(string name)
		{
			if(_toDoListService.CreateToDoList(name))
			{
				return Ok("ToDoList created");
			}

			return BadRequest("Something went wrong");
		}
	}
}