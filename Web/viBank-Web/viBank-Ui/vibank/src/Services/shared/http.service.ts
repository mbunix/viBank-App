import axios from 'axios';
import getConfig from 'next/config';

const { publicRuntimeConfig } = getConfig();

const baseUrl = publicRuntimeConfig.viBankUrl;

export const http = axios.create({
    baseURL: baseUrl
})
function get<T>(url: string, queryParams: Object) {
    return axios.get<T>(`${baseUrl}/${url}`, {
        params: queryParams,
    });
}
function getall<T>(url:string){
    return axios.get<T>(`${baseUrl}/${url}`)
};
function getSingleResourceById<T>(url: string){
    return axios.get<T>(`${baseUrl}/${url}`)
}
function post<T>(url: string, body: Object) {
    return axios.post<T>(`${baseUrl}/${url}`, body);
}
function remove<T>(url: string) {
    return axios.delete<T>(`${baseUrl}/${url}`);
}
function put<T>(url: string, body: Object) {
    return axios.put<T>(`${baseUrl}/${url}`, body);
}
function patch<T>(url: string, body?: Object) {
    return axios.patch<T>(`${baseUrl}/${url}`, body);
}
function setAuthorizationHeader(token: string) {
    axios.defaults.headers.common.Authorization = `Bearer ${token}`;
}
const httpService = { get, getall,patch, post, remove, put, getSingleResourceById, setAuthorizationHeader };

export default httpService;