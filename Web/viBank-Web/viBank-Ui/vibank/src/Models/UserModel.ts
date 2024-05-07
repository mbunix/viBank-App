import { Account } from "./AccountModel"

export type User = {
    username: string,
    email: string,
    password: string,
    role: string,
    id?: string,
    token?: Token,
    account : Account
}

export type Token = {
    token: string
    refreshToken: string
    expires: number;
    user:User
}