import NextAuth, { NextAuthOptions } from "next-auth";
import AzureADProvider from "next-auth/providers/azure-ad"
import GoogleProvider from 'next-auth/providers/google';

export const authOptions: NextAuthOptions = {
  providers: [
    AzureADProvider({
      name: 'Azure Active Directory',
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
        clientId: process.env.GOOGLE_CLIENT_ID ?? 'undefined',
        clientSecret: process.env.GOOGLE_CLIENT_SECRET ?? 'undefined',
      })
  ],
  theme: {
    colorScheme: 'light',
  },
  callbacks: {
    /**
     * Controls
     * @param param{account, profile, user}
     * @returns True iff user is allowed to sign in
     */
    
    async signIn()
    {
      return true
    },
    // user, profile
    async jwt({ token, account }) {
      if (account) {
        token.access_token = account.access_token;
        try {
          const graphClient = getGraphClient(
            {access_token: account.access_token} as { access_token: string }
          )
          token.graphdata = await graphClient.api('/me').get()
        } catch (err) {
          console.error('Failed to load MS Graph data')
          console.error(err)
        }
      }
      return token
    },
    // , user
    async session({ session, token }) {
      // Transform graphdata to user model
      session.userdata = ToUser(token.graphdata)
      return session
    },
  },
  events: {
    async signIn(message) {
      console.log(
        'Logged in successfully: %s',
        JSON.stringify(message.user.name)
      )
    },
    async session(message) {
      console.log(
        'Session active: %s',
        JSON.stringify(message?.session?.user?.name)
      )
    },
  },
}

export default NextAuth(authOptions)