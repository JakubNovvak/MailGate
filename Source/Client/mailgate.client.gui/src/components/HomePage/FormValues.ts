import * as yup from "yup";

export interface FormValues {
    emailSendDate: string;
    targetEmail: string;
    messageSubject: string;
    messageContent: string;
}

export const BasicSchema = yup.object().shape({
    targetEmail: yup.string().email().required("Target email is required."),
    messageSubject: yup.string().min(1).max(90).required("You can't send message without subject."),
    messageContent: yup.string().min(1).max(750).required("You can't send an empty message.")
});

export type FormikChangeHandler = {
    (e: React.ChangeEvent<any>): void;
    <T = string | React.ChangeEvent<any>>(field: T): T extends React.ChangeEvent<any> ? void : (e: string | React.ChangeEvent<any>) => void;
};

export type FormikBlurHandler = {
    (e: React.FocusEvent<any, Element>): void;
    <T = any>(fieldOrEvent: T): T extends string ? (e: any) => void : void;
};