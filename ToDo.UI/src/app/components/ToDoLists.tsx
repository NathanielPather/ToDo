'use client';

import { GetLists } from "../api/api";

function CreateToDoListElements() {
	let HTMLElement: React.JSX.Element[] = [];
	const lists = GetLists();

	if(lists.length > 0) {
		lists.map((list, index) => {
			HTMLElement.push(<div key={index}>{list.name}</div>);
		});
		
		return HTMLElement;
	}

	return (<div>empty</div>);
}

function ToDoLists() {
	return(
		<div>
			<h1>ToDoLists</h1>
			{CreateToDoListElements()}
		</div>
	);
}

export default ToDoLists;