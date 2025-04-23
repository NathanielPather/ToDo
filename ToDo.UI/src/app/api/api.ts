import { MyList } from "./MyList";

const api = `https://localhost:7004/`;

const headers = ({
	"access-control-allow-origin": "*",
	"Content-Type": "application/json"
});

const mode = "cors";

export const GetLists = async () => {
	const response = await fetch(api + "ToDoList/GetToDoLists", {
		method: "GET",
		headers: headers,
		mode: mode,
	});

	if(response.status == 200) {
		const content = await response.json();
		console.log(content);

		return content;
	}
	else {
		const content = await response.text();
		console.log(content)
	}
}


export const CreateList = async (newList: MyList) => {
	const response = await fetch(api + "ToDoList/CreateToDoList", {
		method: "POST",
		headers: headers,
		mode: mode,
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