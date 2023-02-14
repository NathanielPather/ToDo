using ToDo.Core.Interfaces;
using ToDo.Core.Models;

namespace ToDo.Core.Services
{
	public class ToDoListService : IToDoListService
	{
		public bool CreateToDoList()
		{
			ToDoList list = new ToDoList();

		}

		public bool DeleteToDoList()
		{
			throw new NotImplementedException();
		}

		public bool GetToDoList()
		{
			throw new NotImplementedException();
		}

		public bool UpdateToDoList()
		{
			throw new NotImplementedException();
		}
	}
}
