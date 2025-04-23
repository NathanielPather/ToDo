using ToDo.Core.Models;

namespace ToDo.Core.Interfaces
{
	public interface IToDoListService
	{
        IEnumerable<ToDoList> GetToDoLists();
        bool CreateToDoList(string name);
		bool GetToDoList();
		bool UpdateToDoList();
		bool DeleteToDoList();
	}
}
