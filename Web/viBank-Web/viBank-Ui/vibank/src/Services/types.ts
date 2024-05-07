import { User } from "@/Models/UserModel"


export type APICollectionResponse<Results> = {
    map(arg0: (e: any) => any): import("react").SetStateAction<string[] | undefined>
    totalCount: number,
    totalPages: number,
    currentPage: number,
    results: Results
}
export type LoginRequest = {
    email: string,
    password: string
}
export type RegisterRequest = {
    username: string,
    email: string,
    password: string
}
export type userRequest = {
    email: string
}
export type UserResponse = {
    id: number,
    username: string,
    email: string,
    roles: Roles[]
    accessToken: string
    refreshToken: string
    expiresAt: Date
    createdAt: Date
    updatedAt: Date
}
export type LoginResponse = {
    token: string
}
export type Roles = {
    id: number,
    roleId:string,
    name: string
}
export type refreshTokenRequest = {
    accessToken: string,
    refreshToken: string
  }
export type TransferMoneyRequest = {
    email: string,
    amount: number,
    originAccountNumber: number,
    destinationAccountNumber: number,
    transactionType: string,
    transactionID: string,
    accountID: string,
    transactionDate: Date  
}
export type  TransactionResponse = {
    status: string,
    message: string,
    transactionId: string

}
export type DepositMoneyRequest = {
    email: string,
    amount: number,
    accountNumber: number,
    transactionType: string,
    transactionID: string,
    transactionDate: Date
}
export type getBalanceRequest = {
    accountNumber: number,
    email: User['email'],
    
}

export type WithdrawMoneyRequest = {
    email: string,
    amount: number,
    accountNumber: number,
    accountID: string,
    atmLocation: string,
    transactionType: string,
    transactionID: string,
    transactionDate: Date
}