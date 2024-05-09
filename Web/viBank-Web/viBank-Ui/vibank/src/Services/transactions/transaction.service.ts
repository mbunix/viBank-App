import httpService from "../shared/http.service";
import { endpoints } from "../shared/endpoints";
import { DepositMoneyRequest, TransactionResponse, TransferMoneyRequest, WithdrawMoneyRequest, getBalanceRequest, getBalanceResponse } from "../types";

export const transferMoney = async (body: TransferMoneyRequest)=> {
   return  httpService.post<TransactionResponse>(endpoints.transfer, body);
}


export const depositMoney = async(body: DepositMoneyRequest):Promise<TransactionResponse> => {
    const response = await httpService.post<TransactionResponse>(endpoints.deposit, body);
    return response.data;
}

export const withdrawMoney = async(body: WithdrawMoneyRequest) => {
    return httpService.post<TransactionResponse>(endpoints.withdraw, body);
}

export const checkBalance = async(body:string) => {
return  httpService.getSingleResourceById(`${endpoints.checkBalance}${body}`);
}
export const checkATMDetails = async(body:string) => {
return  httpService.getSingleResourceById(`${endpoints.ATMs}${body}`);
}