import { FormValues } from "../FormValues";
import axios from "axios";

export default async function FetchData(formikValues: FormValues, setSendingState: React.Dispatch<React.SetStateAction<boolean>>, setSendSucess: React.Dispatch<React.SetStateAction<number>>) {
    setSendingState(true);
    try {
        await axios.post("https://localhost:7118/api/Tasks", formikValues);
        
        //Simple security-wise connection delay
        // await new Promise(resolve => setTimeout(resolve, 2000));

        setSendingState(false);
        setSendSucess(1);
    }
    catch (error) {
        await new Promise(resolve => setTimeout(resolve, 1000));
        console.log("error");
        setSendingState(false);
        setSendSucess(2);
        await new Promise(resolve => setTimeout(resolve, 4000));
        setSendSucess(0);
    }
}