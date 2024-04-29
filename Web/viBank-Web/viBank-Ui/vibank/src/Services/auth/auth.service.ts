import httpService from "../shared/http.service";
import { endpoints } from "../shared/endpoints";
import { LoginRequest, LoginResponse, RegisterRequest, Roles, UserResponse, refreshTokenRequest, userRequest } from "../types";
import { PrismaClient } from "@prisma/client";

const Prisma = new PrismaClient()

export const login = async (body: LoginRequest): Promise<LoginResponse> => {
    const response = await httpService.post<LoginResponse>(endpoints.auth, body);
    return response.data;
}
export const getUserRoles = async () => {
    const response = await httpService.get<Roles[]>(endpoints.roles,'');
    return response.data;
}
export const getUser = async (body: userRequest): Promise<UserResponse> => {
    const response = await httpService.get<UserResponse>(endpoints.auth, body);
    return response.data;
}
export const refreshToken = async (body: refreshTokenRequest): Promise<LoginResponse> => {
    const response = await httpService.post<LoginResponse>(endpoints.refreshToken, body);
    return response.data;
}

export const createUser = async (body: RegisterRequest): Promise<UserResponse> => {
    const response = await httpService.post<UserResponse>(endpoints.register, body);
    return response.data;
}