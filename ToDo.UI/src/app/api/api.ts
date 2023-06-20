import { MyList } from "./MyList";

const api = `https://localhost:7004/`;

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


export const CreateList = async (newList: MyList) => {
	const response = await fetch(api + "ToDoList/CreateToDoList", {
		method: "POST",
		headers: new Headers({
			"access-control-allow-origin": "*",
			"Content-Type": "application/json"
		}),
		mode: "cors",
		body: JSON.stringify(newList)
	});

	if(response.status == 200) {
		const content = await response.text();
		console.log(content);
	}
}