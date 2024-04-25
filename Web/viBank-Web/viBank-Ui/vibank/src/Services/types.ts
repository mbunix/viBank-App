

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
