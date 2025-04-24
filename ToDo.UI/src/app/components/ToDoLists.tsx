'use client';
import Accordion from "@mui/material/Accordion";
import { GetLists } from "../api/api";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import { ThemeProvider } from "@emotion/react";
import theme from "../themes/theme";
import { useEffect, useState } from "react";

function CreateToDoListElements(lists: ToDoList[]) {
	let HTMLElement: React.JSX.Element[] = [];

	if (lists.length > 0) {
		lists.map((list, index) => {
			HTMLElement.push(
				<Accordion square={true} key={index}>
					<ThemeProvider theme={theme}>
						<AccordionSummary
							aria-controls="panel1a-content"
							id="panel1a-header">
								<div style={{fontFamily: 'roboto'}}>{list.name}</div>
								{/* TODO: Adjust this to match ToDoList model */}
								{/* <div>{list.completed}/{list.totalTasks} {list.resetTimer}</div> */}
						</AccordionSummary>
					</ThemeProvider>
						<AccordionDetails>
							TODO
						</AccordionDetails>
				</Accordion>
			);
		});

		return HTMLElement;
	}

	return (<div>empty</div>);
}

function ToDoLists() {
	const [lists, setLists ]= useState<ToDoList[]>([])
	useEffect(() => {
		const loadLists = async () => {
			const data = await GetLists();
			setLists(data);
		};

		loadLists();
	}, [lists]);

	return (
		<div>
			{CreateToDoListElements(lists)}
		</div>
	);
}

export default ToDoLists;