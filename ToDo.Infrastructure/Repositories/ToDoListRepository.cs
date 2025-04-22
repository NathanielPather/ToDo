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

        public ToDoList? GetToDoListByName(string name)
        {
            // Microsoft.Data.SqlClient.SqlException: 'Invalid object name 'ToDoLists'.'
			// Because the migrations haven't run, there are no objects in the database called ToDoLists
			// ToDoLists is the main database parent object
			// Update Database
            return _context.ToDoLists.FirstOrDefault(toDoList => toDoList.Name.Equals(name));
        }
    }
}
