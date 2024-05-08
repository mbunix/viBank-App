import { Account } from "./AccountModel"
import { refreshToken } from '../Services/auth/auth.service';

export type User = {
    username: string,
    email: string,
    password: string,
    role: string,
    id?: number,
    refreshToken?: Token,
    accountNumber: number,
    account : Account
}

export type Token = {
    token: string
    refreshToken: string
    expires: number;
    user:User
}