import { Box, CircularProgress, Divider, Grid, Paper, Typography, styled } from "@mui/material";
import { Button, Input, Textarea } from "@mui/joy";
import TopPaperComponent from "../../components/HomePage/TopPaperComponent";
import { FormValues, BasicSchema } from "../../components/HomePage/FormValues";
import { Form, Formik, useFormikContext } from "formik";
import GenericFormInput from "../../components/HomePage/GenericFormInput";
import FetchData from "../../components/HomePage/API/FetchData";
import { useEffect, useState } from "react";
import PostErorrSnackbar from "../../components/HomePage/PostSnackbar";

const GridInput = styled(Grid)({
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    marginTop: "0.8rem",
    marginBottom: "0.8rem"
})

function onSubmit(formikValues: FormValues, setSendingState: React.Dispatch<React.SetStateAction<boolean>>, setSendSucess: React.Dispatch<React.SetStateAction<number>>) {
    console.log(formikValues);
    //TODO: Submit the form.
    FetchData(formikValues, setSendingState, setSendSucess);
    console.log("onSubmit");
}

function HomePageContent() {
    const formikProps = useFormikContext<FormValues>();

    useEffect(() => {
        formikProps.validateForm();
    }, []);

    return (
        <Box sx={{ width: "100%", /**backgroundColor: "red"*/ }}>
            <Paper elevation={22} sx={{ minWidth: "70rem", minHeight: "40rem" }}>
                <TopPaperComponent />

                <Divider />
                <Form>
                    <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", minHeight: "23rem", maxHeight: "31rem" }}>
                        <Box sx={{/**backgroundColor: "red",*/ width: "60%" }}>

                            {/*Field number 1*/}
                            <GridInput container>
                                <GenericFormInput textInfo={["targetEmail", "To:", "Target email address"]} FormikValue={formikProps.values.targetEmail}
                                    FormikChangeHandler={formikProps.handleChange} FormikBlurHandler={formikProps.handleBlur}
                                    formikError={formikProps.errors.targetEmail} formikTouched={formikProps.touched.targetEmail}
                                />
                            </GridInput>

                            {/*Field number 2*/}
                            <GridInput container>
                                <GenericFormInput textInfo={["messageSubject", "Subject:", "Type your message's subject"]} FormikValue={formikProps.values.messageSubject}
                                    FormikChangeHandler={formikProps.handleChange} FormikBlurHandler={formikProps.handleBlur}
                                    formikError={formikProps.errors.messageSubject} formikTouched={formikProps.touched.messageSubject}
                                />
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
                                        placeholder="Type your message here" name="messageContent"
                                        value={formikProps.values.messageContent} onChange={formikProps.handleChange} onBlur={formikProps.handleBlur}
                                        color={
                                            formikProps.touched.messageContent && formikProps.errors.messageContent ? "danger" :
                                                formikProps.touched.messageContent && formikProps.errors.messageContent === undefined ? "success"
                                                    : "neutral"}
                                    />
                                </Grid>
                            </GridInput>

                            {/*Button*/}
                            <GridInput container>
                                <Grid item xs={10}>{/*placeholder*/}</Grid>
                                <Grid item xs={2}>
                                    {!formikProps.isValid
                                        ?
                                        <Button disabled sx={{ color: "black", backgroundColor: "lightgray" }}>Submit</Button>
                                        :
                                        <Button type="submit" sx={{ color: "black", backgroundColor: "lightBlue" }}>Submit</Button>
                                    }

                                </Grid>
                            </GridInput>
                        </Box>
                    </Box>
                </Form>
            </Paper>
        </Box>
    );
}

export default function HomePage() {
    const [sendingState, setSendingState] = useState<boolean>(false);
    const [sendSucess, setSendSucess] = useState<number>(0);
    //0 - neutral, 1 - success, 2 - failed, 3 - Connected but send failed

    if (sendingState) {
        return (
            <Box sx={{ width: "100%", /**backgroundColor: "red"*/ }}>
                <Paper elevation={22} sx={{ minWidth: "70rem", minHeight: "40rem" }}>
                    <Box sx={{ display: 'flex', flexDirection: "column", justifyContent: "center", alignItems: "center", width: "100%", height: "40rem" }}>
                        <CircularProgress size={50} />
                    </Box>
                </Paper>
            </Box>
        );
    }

    // if (sendSucess == 2) {
    //     setSendSucess(0);
    // }

    return (
        <>
            {sendSucess == 1 ? <PostErorrSnackbar TextIndex={2} IsDangerSnackBar={false}/> : <></>}
            {sendSucess == 2 ? <PostErorrSnackbar TextIndex={0} IsDangerSnackBar={true}/> : <></>}
            {sendSucess == 3 ? <PostErorrSnackbar TextIndex={1} IsDangerSnackBar={true}/> : <></>}
            <Formik initialValues={{ messageContent: "", messageSubject: "", targetEmail: ""}}
                onSubmit={(values) => { onSubmit(values, setSendingState, setSendSucess) }}
                validationSchema={BasicSchema}
            >
                <HomePageContent />
            </Formik>
        </>
    );
}