import { Typography, Grid } from "@mui/material";
import { Input } from "@mui/joy";
import { FormikBlurHandler, FormikChangeHandler } from "../../components/HomePage/FormValues";

export default function GenericFormInput({ textInfo, FormikValue, FormikBlurHandler, FormikChangeHandler, formikError, formikTouched }:
    { textInfo: string[], FormikValue: string, FormikBlurHandler: FormikBlurHandler, FormikChangeHandler: FormikChangeHandler, formikError: string | undefined, formikTouched: boolean | undefined }) {
    const inputId = textInfo[0];
    const leftLabel = textInfo[1];
    const placeholder = textInfo[2];

    return (<>
        <Grid item xs={3} sx={{/**backgroundColor: "blue"*/ }}>
            <Typography variant="body1" sx={{ marginRight: "1rem" }}>
                {leftLabel}
            </Typography>
        </Grid>
        <Grid item xs={9}>
            <Input
                id={inputId}
                value={FormikValue}
                sx={{ minWidth: "30rem", maxWidth: "40rem" }}
                placeholder={placeholder}
                onChange={FormikChangeHandler} onBlur={FormikBlurHandler}
                color={formikTouched && formikError ? "danger" : formikTouched && formikError === undefined ? "success" : "neutral"}
            >
            </Input>
        </Grid>
    </>);
}