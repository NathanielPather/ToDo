namespace ToDo.Core.Interfaces
{
	public interface IToDoListService
	{
		bool CreateToDoList();
		bool GetToDoList();
		bool UpdateToDoList();
		bool DeleteToDoList();
	}
}
