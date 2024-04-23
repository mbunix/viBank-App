import NextAuth from "next-auth";
import { JWT } from "next-auth/jwt";
declare module "next-auth" {
    interface Session {
        accessToken: string,
        refreshToken: string,
        expires: string

    }
    interface User {
        email: string
        image: string
    }
    interface JWT {
        idToken: string
    }
}