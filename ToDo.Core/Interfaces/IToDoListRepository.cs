using ToDo.Core.Models;

namespace ToDo.Infrastructure.Interfaces
{
	public interface IToDoListRepository
	{
		bool CreateToDoList(ToDoList list);
        bool DeleteToDoList(int id);
        ToDoList? GetToDoListByName(string name);
		IEnumerable<ToDoList> GetToDoLists();
	}
}
