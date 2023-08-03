using ToDo.Core.Models;

namespace ToDo.API.Tests
{
    public class ToDoMockData
    {
        public static List<ToDoList> GetToDoList()
        {
            return new List<ToDoList> {
                new ToDoList {
                    Name = "Work"
                },
                new ToDoList {
                    Name = "Chores"
                },
                new ToDoList {
                    Name = "Piano"
                },
                new ToDoList {
                    Name = "League of Legends"
                }
            };
        }
    }
}
