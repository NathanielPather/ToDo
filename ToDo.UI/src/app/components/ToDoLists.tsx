'use client';
import Accordion from "@mui/material/Accordion";
import { GetLists } from "../api/api";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import { ThemeProvider } from "@emotion/react";
import theme from "../themes/theme";

function CreateToDoListElements() {
	let HTMLElement: React.JSX.Element[] = [];
	const lists: ToDoList[] = GetLists();

	if (lists.length > 0) {
		lists.map((list, index) => {
			HTMLElement.push(
				<ThemeProvider theme={theme} key={index}>
					<Accordion square={true}>
						<AccordionSummary
							aria-controls="panel1a-content"
							id="panel1a-header">
								<div>{list.name}</div>
								<div>{list.completed}/{list.totalTasks} {list.resetTimer}</div>
						</AccordionSummary>
						<AccordionDetails>
							TODO
						</AccordionDetails>
					</Accordion>
				</ThemeProvider>
			);
		});

		return HTMLElement;
	}

	return (<div>empty</div>);
}

function ToDoLists() {
	return (
		<div>
			<h1>ToDoLists</h1>
			{CreateToDoListElements()}
		</div>
	);
}

export default ToDoLists;