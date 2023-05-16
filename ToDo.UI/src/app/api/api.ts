

const lists: ToDoList[] = [
	{ 
		name: "work",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
	{ 
		name: "Music",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
	{ 
		name: "League",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
]

export function GetLists() {
	return lists;
}