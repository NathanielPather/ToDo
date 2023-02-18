using ToDo.Core.Models;

namespace ToDo.Infrastructure.Interfaces
{
	public interface IToDoListRepository
	{
		bool CreateToDoList(ToDoList list);
	}
}
