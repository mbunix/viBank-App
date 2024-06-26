import { User } from "@/Models/UserModel";
import { Token } from "@/Models/UserModel";
import { TOKEN_NAME } from "@/contexts/constants";

export function setToken(token: Token) {
    localStorage.setItem(TOKEN_NAME, JSON.stringify(token));
}
export function setAccountDetails(user: User) {
    localStorage.setItem('account', JSON.stringify(user));
}
export function getToken(): Token | null{
    const token = localStorage.getItem(TOKEN_NAME);
    if (token) {
        return JSON.parse(token);
    }
    return null;
}
export function getAccountDetails(): User | null {
    const account = localStorage.getItem('account');
    if (account) {
        return JSON.parse(account);
    }
    return null;
}
export function removeToken() {
    localStorage.removeItem(TOKEN_NAME);
}
