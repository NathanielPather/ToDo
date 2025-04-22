import { createTheme } from "@mui/material/styles";
import { green } from "./colours";

const theme = createTheme({
	components: {
		MuiAccordion: {
			styleOverrides: {
				root: {
					background: green
				}
			}
		},
		MuiAccordionSummary: {
			styleOverrides: {
				content: {
					display: "flex",
					justifyContent: "space-between",
					fontWeight: 100,
					fontSize: 25,
					paddingLeft: 20,
					paddingRight: 20
				}
			}
		}
	},
	typography: {
		fontFamily: 'roboto'
	}
});

export default theme;