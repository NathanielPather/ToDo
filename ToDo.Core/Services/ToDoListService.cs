﻿using ToDo.Core.Interfaces;
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
			return _toDoListRepository.CreateToDoList(list);
		}

		public bool DeleteToDoList()
		{
			throw new NotImplementedException();
		}

		public bool GetToDoList()
		{
			throw new NotImplementedException();
		}

		public bool UpdateToDoList()
		{
			throw new NotImplementedException();
		}
	}
}
