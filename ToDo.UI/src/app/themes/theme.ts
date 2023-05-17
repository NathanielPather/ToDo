import { green } from "@mui/material/colors";
import { createTheme } from "@mui/material/styles";

const theme = createTheme({
	components: {
		MuiAccordion: {
			styleOverrides: {
				root: {
					background: green[500]
				}
			}
		},
		MuiAccordionSummary: {
			styleOverrides: {
				content: {
					display: "flex",
					justifyContent: "space-between"
				}
			}
		}

	}
});

export default theme;