export type User = {
    username: string,
    email: string,
    password: string,
    role: string,
    id?: string
}

export type Token = {
    token: string
    refreshToken: string
    expires: number;
    user:User
}