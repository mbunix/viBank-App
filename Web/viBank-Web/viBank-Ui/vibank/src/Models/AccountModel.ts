export type Account = {
    AccountBalance: number,
    id?: string,
    AccountNumber: string,
    userId?: string,
    accountType: AccountType,
    createdDTM?: Date,
    updatedDTM?: Date,
    UserEmail?: string
}

export enum AccountType {
    savings = "savings",
    current = "current",
    loan = "loan",
    credit = "credit"
}