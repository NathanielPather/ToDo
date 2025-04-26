"use client"
import { Button } from "@mui/material";
import ToDoLists from "./components/ToDoLists";
import { CreateList } from "./api/api";
import { MyList } from "./api/MyList";
import { ThemeProvider } from "@emotion/react";
import theme from "./themes/theme";
import CreateToDoListDialog from "./components/CreateToDoListDialog";
import { useState } from "react";
import { useQueryClient, useMutation } from "@tanstack/react-query";

// All component functions must be non async
// Async functions cause infinite re-renders
// Async flow::
// React sees async function Home(): promise
// Waits for promise to resolve
// When promise resolves it tries to render the component
// The component returns a promise, react waits ...
// Infinite loop
export default function Home() {
	const [open, setOpen] = useState(false)
	const queryClient = useQueryClient();

	function OnSave(listName: string) {
		createMutation.mutate({ name: listName });
	}
	const createMutation = useMutation({
		mutationFn: CreateList,
		onSuccess: () => {
			queryClient.invalidateQueries({ queryKey: ['todoLists'] });
		},
	});

	return (
		<div>
			<ThemeProvider theme={theme}>
				<div style={{ display: "flex", justifyContent: "space-between" }}>
					<h1 style={{ fontFamily: "roboto" }}>ToDoLists</h1>
					<Button onClick={() => setOpen(true)} variant="outlined" style={{ border: 'none', fontSize: 40, fontWeight: 100 }}>
							+
					</Button>
				</div>
				<ToDoLists />
			</ThemeProvider>
			<CreateToDoListDialog isOpen={open} onSave={OnSave} onClose={() => setOpen(false)} />
		</div>
	)
}
