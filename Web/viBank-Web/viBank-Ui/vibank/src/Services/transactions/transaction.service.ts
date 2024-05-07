import httpService from "../shared/http.service";
import { endpoints } from "../shared/endpoints";
import { DepositMoneyRequest, TransactionResponse, TransferMoneyRequest, WithdrawMoneyRequest, getBalanceRequest } from "../types";

export const transferMoney = async (body: TransferMoneyRequest):Promise<TransactionResponse> => {
    const response = await httpService.post<TransactionResponse>(endpoints.transfer, body);
    return response.data;
}


export const depositMoney = async(body: DepositMoneyRequest):Promise<TransactionResponse> => {
    const response = await httpService.post<TransactionResponse>(endpoints.deposit, body);
    return response.data;
}

export const withdrawMoney = async(body: WithdrawMoneyRequest):Promise<TransactionResponse> => {
    const response = await httpService.post<TransactionResponse>(endpoints.withdraw, body);
    return response.data;
}

export const checkBalance = async(body: getBalanceRequest):Promise<TransactionResponse> => {
    const response = await httpService.post<TransactionResponse>(endpoints.checkBalance, body);
    return response.data;
}