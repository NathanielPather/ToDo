namespace ToDo.Core.Interfaces
{
	public interface IToDoListService
	{
		bool CreateToDoList(string name);
		bool GetToDoList();
		bool UpdateToDoList();
		bool DeleteToDoList();
	}
}
