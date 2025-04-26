using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetToDoLists")]
        public IActionResult GetAllToDoLists()
		{
			var toDoLists = _toDoListService.GetToDoLists();
			return Ok(toDoLists);
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

        [HttpDelete("DeleteToDoList/{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            try
            {
                var isDeleted = _toDoListService.DeleteToDoList(id);
                if (isDeleted)
                {
                    return Ok("ToDoList deleted successfully.");
                }
                else
                {
                    return NotFound("ToDoList not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the ToDoList.");
            }
        }
    }
}