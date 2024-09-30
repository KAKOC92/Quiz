import { IQuiz } from "../interfaces/iQuiz";

export const getQuizesList = async (tprm: any): Promise<IQuiz[]> => {
    let result: IQuiz[] = [];
    const options = {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    };

    const response = await fetch('/api/Quiz', options);
    if (response.ok) {
        result = await response.json();
    }
    return result;
};