import { Account } from "./AccountModel"
import { ATM } from "./AtmModel"

export enum TransactionType {
    withdraw = "withdraw",
    deposit = "deposit",
    transfer = "transfer"
}
export type Transaction = {
    id: string,
    amount: number,
    originAccountNumber?: Account["AccountNumber"],
    destinationAccountNumber?: Account["AccountNumber"],
    accountID: string,
    atmLocation?: string,
    transactionType: TransactionType,
    transactionID: string,
    transactionDate: Date
    AtmID? : ATM["id"]
}