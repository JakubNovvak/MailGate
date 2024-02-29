import axios from "axios";

export default async function FetchData(setSendingState: React.Dispatch<React.SetStateAction<boolean>>, setSendSucess: React.Dispatch<React.SetStateAction<number>>) {
    setSendingState(true);
    try {
        //axios.post("<post-url>");
        await new Promise(resolve => setTimeout(resolve, 2000));
        setSendingState(false);
        setSendSucess(1);
    }
    catch (error) {
        console.log("error");
        setSendingState(false);
        setSendSucess(2);
    }

    return ("");
}