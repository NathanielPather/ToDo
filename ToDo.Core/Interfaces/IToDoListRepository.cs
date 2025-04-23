using ToDo.Core.Models;

namespace ToDo.Infrastructure.Interfaces
{
	public interface IToDoListRepository
	{
		bool CreateToDoList(ToDoList list);
		ToDoList? GetToDoListByName(string name);
		IEnumerable<ToDoList> GetToDoLists();
	}
}
