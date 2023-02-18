using ToDo.Core.Models;
using ToDo.Infrastructure.Interfaces;

namespace ToDo.Infrastructure.Repositories
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly Context _context;
		public ToDoListRepository(Context context) {
			_context = context;
		}
		public bool CreateToDoList(ToDoList list)
		{
			_context.ToDoLists.Add(list);
			
			try {
				_context.SaveChanges();
			}
			catch { 
				return false;
			}

			return true;
		}
	}
}
