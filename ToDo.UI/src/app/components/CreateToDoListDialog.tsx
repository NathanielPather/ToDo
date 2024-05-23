import { Button, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material';
import Dialog from '@mui/material/Dialog';
import { useState } from 'react';

type CreateToDoListDialogProps = {
	isOpen: boolean;
	onSave: (inputName: string) => void;
	onClose: () => void;
}

function CreateToDoListDialog({isOpen, onSave, onClose} : CreateToDoListDialogProps) {
	const [inputValue, setInputValue] = useState("");

	const HandleClose = () => {
		setInputValue("")
		onClose()
	}
	
	// Inner save logic
	// Does not actually contain save logic
	// Calls the parents save logic
	// passing the input as a parameter
	const HandleSave = () => {
		onSave(inputValue)
		onClose();
	}

	return (
		<Dialog open={isOpen} onClose={onClose}>
			<DialogTitle>Create new ToDo List</DialogTitle>
			<DialogContent>
				{/* This is how we set the text value
				We create a state
				And update it as the text field changes
				On save we pass the final value */}
				<TextField
					id="standard-basic"
					label="ToDo List Name"
					variant="standard"
					onChange={(e) => setInputValue(e.target.value)
				}/>
			</DialogContent>
			<DialogActions>
				<Button onClick={HandleClose}>Cancel</Button>
				<Button onClick={HandleSave}>Save</Button>
			</DialogActions>
		</Dialog>
	)
}

export default CreateToDoListDialog;