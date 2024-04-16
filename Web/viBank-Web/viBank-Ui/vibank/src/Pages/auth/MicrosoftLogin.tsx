import NextAuth from "next-auth/next";
import AzureAD from "next-auth/providers/azure-ad";
import { Button, IconButton, Typography } from "@material-tailwind/react";

export default  function MicrosoftSignIn() {
    return (
        <Button variant="gradient" size="sm" fullWidth className="mb-2" placeholder={"sign in with microsoft"}>
            <Typography variant="small" color="white" className="font-medium" placeholder={"microsoft"}>
                <IconButton variant= "text" placeholder={"microsoft"}>
                    <img src ="public/icons8-microsoft-azure.svg" alt="logo" className="w-4"/>
                    Sign in with Microsoft
                </IconButton>
        <NextAuth
            providers={[
                AzureAD({
                    clientId: process.env.NEXT_PUBLIC_AZURE_CLIENT_ID as string,
                    clientSecret: process.env.NEXT_PUBLIC_AZURE_CLIENT_SECRET as string,
                    tenantId: process.env.NEXT_PUBLIC_AZURE_TENANT_ID as string,
                }),
            ]}
            />
            </Typography>

        </Button>
    )
}