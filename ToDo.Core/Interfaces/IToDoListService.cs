using ToDo.Core.Models;

namespace ToDo.Core.Interfaces
{
	public interface IToDoListService
	{
        bool CreateToDoList(string name);
        IEnumerable<ToDoList> GetToDoLists();
        ToDoList? GetToDoList(int id);
		bool DeleteToDoList(int id);
        bool UpdateToDoList(int id, string newName);
	}
}
