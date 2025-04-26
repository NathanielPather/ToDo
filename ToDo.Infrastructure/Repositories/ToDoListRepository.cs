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

		public IEnumerable<ToDoList> GetToDoLists()
		{
			return _context.ToDoLists.ToList();
		}

        public bool DeleteToDoList(int id) 
        {
            var toDoList = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            if (toDoList == null)
            {
                return false;
            }

            _context.ToDoLists.Remove(toDoList);

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
