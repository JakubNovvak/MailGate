import { Paper, Typography } from "@mui/material";

export default function TopPaperComponent() {
    return (
        <>
            <Paper elevation={3} sx={{ width: "100%", backgroundColor: "none", display: "flex", flexDirection: "column" }}>
                <Typography variant="h3" mt={"1.5rem"} mb={"1rem"}>
                    Hello and welcome!
                </Typography>
                <Typography variant="h5" mb={"1rem"}>
                    Use this mailing system as much as you want - just fill the form and voila!
                </Typography>
            </Paper>
        </>
    );
}