"use client"
import { Button } from "@mui/material";
import ToDoLists from "./components/ToDoLists";
import { CreateList } from "./api/api";
import { MyList } from "./api/MyList";

function MyAlert() {
	const newList = new MyList("Nathaniel");
	CreateList(newList);
}

export default async function Home() {
	return (
		<div>
			<ToDoLists />
			<Button 
				onClick={() => {
					MyAlert()
				}}
				variant="outlined">
					Add New To Do List
			</Button>
		</div>
	)
}


