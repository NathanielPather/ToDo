import { MyList } from "./MyList";

const api = `https://localhost:7004/`;

const localListMock: ToDoList[] = [
	{
		name: "Work Tasks",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
	{
		name: "Home Tasks",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
	{
		name: "Personal Project Tasks",
		completed: 2,
		totalTasks: 5,
		resetTimer: "13:23:25"
	},
]

export function GetLists() {
	return localListMock;
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
	else {
		const content = await response.text();
		console.log(content)
	}
}