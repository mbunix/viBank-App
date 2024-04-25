import { NextApiHandler } from 'next';
import NextAuth from 'next-auth';
import { PrismaAdapter } from '@next-auth/prisma-adapter';
import { JWT } from 'next-auth/jwt';
import AzureADProvider from "next-auth/providers/azure-ad"

import GoogleProvider from 'next-auth/providers/google';
import prisma from '@/Utils/prisma';
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

const options = {
  providers: [
       AzureADProvider({
      name: 'microsoft',
      clientId: process.env.AZURE_CLIENT_ID ?? 'undefined',
      clientSecret: process.env.AZURE_CLIENT_SECRET ?? 'undefined',
      tenantId: process.env.AZURE_TENANT_ID,
      authorization: {
        params: {
          scope: 'api://ownscope/general openid profile email user.read ',
        },
      },
    }),
    GoogleProvider({
        name: 'google',
        clientId: process.env.GOOGLE_CLIENT_ID ?? 'undefined',
        clientSecret: process.env.GOOGLE_CLIENT_SECRET ?? 'undefined',
      })
  ],
  pages: {
    error: '/auth/error', 
  },
  callbacks: {
    async jwt({ token, user }: { token: JWT; user: any }) {
      if (user) {
        token.id = user.id;
      }
      console.log(token)
      return token;
    },
    async session({ session, token }: { session: any; token: JWT }) {
      if (token) {
        session.id = token.id;
      }
      return session;
    },
  },
  adapter: PrismaAdapter(prisma),
  secret: process.env.SECRET,
};

const authHandler = NextAuth(options);
export default async function handler(...params: any[]) {
  await authHandler(...params);
}



