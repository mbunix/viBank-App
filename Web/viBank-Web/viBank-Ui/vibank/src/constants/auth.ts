import { Token } from "@/Models/UserModel";
import { TOKEN_NAME } from "@/contexts/constants";

export function setToken(token: Token) {
    localStorage.setItem(TOKEN_NAME, JSON.stringify(token));
}

export function getToken(): Token | null{
    const token = localStorage.getItem(TOKEN_NAME);
    if (token) {
        return JSON.parse(token);
    }
    return null;
}

export function removeToken() {
    localStorage.removeItem(TOKEN_NAME);
}
