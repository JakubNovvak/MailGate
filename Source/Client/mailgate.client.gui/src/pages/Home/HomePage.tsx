import { Box, Divider, Grid, Paper, Typography, styled } from "@mui/material";
import { Button, Input, Textarea } from "@mui/joy";
import TopPaperComponent from "../../components/HomePage/TopPaperComponent";

const GridInput = styled(Grid)({
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    marginTop: "0.8rem",
    marginBottom: "0.8rem"
})
export default function HomePage() {
    return (
        <Box sx={{ width: "100%", /**backgroundColor: "red"*/ }}>
            <Paper elevation={22} sx={{ minWidth: "70rem", minHeight: "40rem" }}>
                <TopPaperComponent />

                <Divider />

                <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", minHeight: "23rem", maxHeight: "31rem" }}>
                    <Box sx={{/**backgroundColor: "red",*/ width: "60%" }}>

                        {/*Field number 1*/}
                        <GridInput container>
                            <Grid item xs={3} sx={{/**backgroundColor: "blue"*/ }}>
                                <Typography variant="body1" sx={{ marginRight: "1rem" }}>
                                    {"To:"}
                                </Typography>
                            </Grid>
                            <Grid item xs={9}>
                                <Input
                                    sx={{ minWidth: "30rem", maxWidth: "40rem" }}
                                    placeholder="Target e-mail address"
                                >
                                </Input>
                            </Grid>
                        </GridInput>

                        {/*Field number 2*/}
                        <GridInput container>
                            <Grid item xs={3} sx={{/**backgroundColor: "blue"*/ }}>
                                <Typography variant="body1" sx={{ marginRight: "1rem" }}>
                                    {"Subject:"}
                                </Typography>
                            </Grid>
                            <Grid item xs={9}>
                                <Input
                                    sx={{ minWidth: "30rem", maxWidth: "40rem" }}
                                    placeholder="Type your e-mail subject"
                                >
                                </Input>
                            </Grid>
                        </GridInput>

                        {/*Field number 3*/}
                        <GridInput container>
                            <Grid item xs={3} sx={{/**backgroundColor: "blue",*/ display: "flex", flexDirection: "column", minHeight: "10rem" }}>
                                <Typography variant="body1" sx={{ marginRight: "1rem" }}>
                                    {"Content:"}
                                </Typography>
                            </Grid>
                            <Grid item xs={9}>
                                <Textarea sx={{ minWidth: "30rem", maxWidth: "40rem", minHeight: "10rem", maxHeight: "18rem" }}
                                    placeholder="Type your message here"
                                >

                                </Textarea>
                            </Grid>
                        </GridInput>

                        {/*Button*/}
                        <GridInput container>
                            <Grid item xs={10}>{/*placeholder*/}</Grid>
                            <Grid item xs={2}>
                                <Button>Submit</Button>
                            </Grid>
                        </GridInput>
                    </Box>
                </Box>

            </Paper>
        </Box>
    );
}