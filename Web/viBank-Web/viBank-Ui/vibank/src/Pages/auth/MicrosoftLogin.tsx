import NextAuth from "next-auth";
import AzureADProvider from "next-auth/providers/azure-ad";
import * as msal from "@azure/msal-node";
import { JWT } from "next-auth/jwt";
import { NextApiRequest, NextApiResponse } from "next";
import { Button, IconButton, Typography } from "@material-tailwind/react";

export default function MicrosoftSignIn({ onSuccess, onError }: { onSuccess: () => void; onError: (error: any) => void }) {
    const clientId = process.env.AZURE_AD_CLIENT_ID;
    const clientSecret = process.env.AZURE_AD_CLIENT_SECRET;
    const tenantId = process.env.AZURE_AD_TENANT_ID;
    const authority = `https://login.microsoftonline.com/${tenantId}`;

    const config = {
        auth: {
            clientId: clientId || "",
            authority,
            clientSecret: clientSecret || "",
            knownAuthorities: [authority],
        },
        system: {
            loggerOptions: {
                loggerCallback(message: string, loglevel: msal.LogLevel, containsPii: boolean) {
                    console.log(message);
                },
                piiLoggingEnabled: false,
                logLevel: msal.LogLevel.Verbose,
            },
        },
    };

    const msalClient = new msal.ConfidentialClientApplication(config);
    const generateApiAccessToken = async (refreshToken: string) =>
        await msalClient
            .acquireTokenByRefreshToken({
                scopes: [`api://${clientId}/APIScope`],
                refreshToken,
            })
            .catch((err) => console.log(err));

    async function refreshAccessToken(token: JWT) {
        try {
            const tokenUrl = `https://login.microsoftonline.com/${tenantId}/oauth2/v2.0/token?`;

            let formData = {
                client_id: clientId,
                grant_type: "refresh_token",
                client_secret: clientSecret,
                refresh_token: token.refreshToken,
            };

            const encodeFormData = (data: any) => {
                return Object.keys(data)
                    .map((key) => encodeURIComponent(key) + "=" + encodeURIComponent(data[key]))
                    .join("&");
            };

            const response = await fetch(tokenUrl, {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                },
                method: "POST",
                body: encodeFormData(formData),
            });

            const refreshedTokens = await response.json();

            if (!response.ok) {
                throw refreshedTokens;
            }

            const refreshToken = refreshedTokens?.refresh_token as string;
            if (refreshToken) {
                token.apiTokenDetails = await generateApiAccessToken(refreshToken);
            }

            return {
                ...token,
                idToken: refreshedTokens.id_token,
                graphAccessToken: refreshedTokens.access_token,
                accessTokenExpires: Date.now() + refreshedTokens.expires_in * 1000,
                refreshToken: refreshedTokens.refresh_token ?? token.refreshToken, // Fall back to old refresh token
            };
        } catch (error) {
            console.log(error);
            return {
                ...token,
                error: "RefreshAccessTokenError",
            };
        }
    }
    
    const handleMicrosoftLogin = async () => {
        try {
            const response = await msalClient.acquireTokenByCode({
                code: "microsoft-auth",
                redirectUri: "http://localhost:3000",
                scopes: ["User.Read"],
            });

            if (response) {
                onSuccess();
            } else {
                onError("Authentication failed");
            }
        } catch (error) {
            console.log(error);
            onError(error);
        }
    };
    return (
        <Button variant="gradient" size="sm" fullWidth className="mb-2" placeholder={"sign in with microsoft"}>
            <Typography variant="small" color="white" className="font-medium" placeholder={"microsoft"}>
                <IconButton variant="text" placeholder={"microsoft"} onClick ={()=>handleMicrosoftLogin( )}>
                    <img src="public/icons8-microsoft-azure.svg" alt="logo" className="w-4" />
                    Sign in with Microsoft
                </IconButton>
            </Typography>
        </Button>
    );
}
