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
				<Accordion square={true} key={index}>
					<ThemeProvider theme={theme}>
						<AccordionSummary
							aria-controls="panel1a-content"
							id="panel1a-header">
								<div style={{fontFamily: 'roboto'}}>{list.name}</div>
								<div>{list.completed}/{list.totalTasks} {list.resetTimer}</div>
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
	return (
		<div>
			{CreateToDoListElements()}
		</div>
	);
}

export default ToDoLists;