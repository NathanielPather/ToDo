'use client';
import Accordion from "@mui/material/Accordion";
import { GetLists } from "../api/api";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import { ThemeProvider } from "@emotion/react";
import theme from "../themes/theme";
import { useQuery} from "@tanstack/react-query";

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
	const { data: lists = [], isLoading, isError } = useQuery({
		queryKey: ['todoLists'],
		queryFn: () => {
			return GetLists();
		},
	});

	if (isLoading) return <div>Loading...</div>;
	if (isError) return <div>Error loading to-do lists.</div>;

	return (
		<div>
			{CreateToDoListElements(lists)}
		</div>
	);
}

export default ToDoLists;