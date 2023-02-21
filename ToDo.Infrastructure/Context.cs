using Microsoft.EntityFrameworkCore;
using ToDo.Core.Models;

namespace ToDo.Infrastructure
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options) { 
		}

		public DbSet<ToDoList> ToDoLists { get; set; }
	}
}