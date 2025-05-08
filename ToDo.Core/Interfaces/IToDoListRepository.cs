using ToDo.Core.Models;

namespace ToDo.Infrastructure.Interfaces
{
	public interface IToDoListRepository
	{
		bool CreateToDoList(ToDoList list);
        IEnumerable<ToDoList> GetToDoLists();
        ToDoList? GetToDoList(int id);
        ToDoList? GetToDoListByName(string name);
        bool DeleteToDoList(int id);
        bool UpdateToDoList(ToDoList updatedList);
	}
}
