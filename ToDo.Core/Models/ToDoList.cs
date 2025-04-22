namespace ToDo.Core.Models
{
	public class ToDoList : BaseModel
	{
        public required string Name { get; set; }
        public TimeSpan? Duration { get; set; }
		public bool? Repeating { get; set; }

    }
}
