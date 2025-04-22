using Microsoft.AspNetCore.Mvc;
using System.Data;
using ToDo.Core.Interfaces;
using ToDo.Core.Models;

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
		public IActionResult CreateToDoList(ToDoList list)
		{
			try
			{
				if(_toDoListService.CreateToDoList(list.Name))
				{
					return Ok("ToDoList created");
				}
			}
			catch (DuplicateNameException ex)
			{
				return BadRequest("ToDoList name already exists.");
            }

			return BadRequest("Something went wrong");
		}
	}
}