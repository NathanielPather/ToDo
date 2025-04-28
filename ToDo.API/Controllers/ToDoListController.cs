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

        [HttpPost("CreateToDoList")]
        public IActionResult CreateToDoList(ToDoList list)
        {
            try
            {
                if (_toDoListService.CreateToDoList(list.Name))
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

        [HttpGet("GetToDoLists")]
        public IActionResult GetAllToDoLists()
        {
            var toDoLists = _toDoListService.GetToDoLists();
            return Ok(toDoLists);
        }

        [HttpGet("GetToDoList/{id}")]
        public IActionResult GetToDoList(int id)
        {
            try
            {
                var toDoList = _toDoListService.GetToDoList(id);
                if (toDoList != null)
                {
                    return Ok(toDoList);
                }
                else
                {
                    return NotFound("ToDoList not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the ToDoList.");
            }
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

        [HttpPut("UpdateToDoList/{id}")]
        public IActionResult UpdateToDoList(int id, ToDoList updatedList)
        {
            if (id != updatedList.Id)
            {
                return BadRequest("Mismatch between route id and ToDoList id.");
            }

            try
            {
                var isUpdated = _toDoListService.UpdateToDoList(id, updatedList.Name);
                if (isUpdated)
                {
                    return Ok("ToDoList updated successfully.");
                }
                else
                {
                    return NotFound("ToDoList not found.");
                }
            }
            catch (DuplicateNameException ex)
            {
                return BadRequest("A ToDoList with this name already exists.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}