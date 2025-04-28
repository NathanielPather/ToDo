using System.Data;
using ToDo.Core.Interfaces;
using ToDo.Core.Models;
using ToDo.Infrastructure.Interfaces;

namespace ToDo.Core.Services
{
	public class ToDoListService : IToDoListService
	{
		private readonly IToDoListRepository _toDoListRepository;
		public ToDoListService(IToDoListRepository toDoListRepository) {
			_toDoListRepository = toDoListRepository;
		}
		public bool CreateToDoList(string name)
		{
			ToDoList list = new ToDoList
			{
				Name = name
			};

			if (_toDoListRepository.GetToDoListByName(list.Name) is not null)
			{
				throw new DuplicateNameException();
			}

			return _toDoListRepository.CreateToDoList(list);
		}

		public IEnumerable<ToDoList> GetToDoLists()
		{
			return _toDoListRepository.GetToDoLists();
		}
        public ToDoList? GetToDoList(int id)
        {
            return _toDoListRepository.GetToDoList(id);
        }

		public bool DeleteToDoList(int id)
		{
			return _toDoListRepository.DeleteToDoList(id);
		}


        public bool GetToDoListByName()
		{
			throw new NotImplementedException();
		}

		public bool UpdateToDoList(int id, string newName)
		{
			var toDoList = _toDoListRepository.GetToDoList(id);
			if (toDoList == null)
			{
				return false;
			}

			var existingList = _toDoListRepository.GetToDoListByName(newName);
			if (existingList != null && existingList.Id != id)
			{
				throw new DuplicateNameException();
			}

			toDoList.Name = newName;
			return _toDoListRepository.UpdateToDoList(toDoList);
		}
	}
}
