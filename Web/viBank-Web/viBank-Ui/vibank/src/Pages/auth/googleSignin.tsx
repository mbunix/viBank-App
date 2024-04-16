import React,{ useState, useEffect } from "react";
import { Button, IconButton, Typography } from "@material-tailwind/react";
import NextAuth from "next-auth/next";
import GoogleProvider from "next-auth/providers/google";
export default function GoogleSignIn() {
    const [isGoogleSignIn, setIsGoogleSignIn] = useState(false);
    return (
        <Button variant="gradient" size="sm" fullWidth className="mb-2" placeholder={"sign in with google"}>
            <Typography variant="small" color="white" className="font-medium" placeholder={"google"}>
                <IconButton variant= "text" placeholder={"google"}>
                    <img src ="public/icons8-google.svg" alt="logo" className="w-4"/>
                        Sign in with Google
                </IconButton>
                <NextAuth
                    providers={[
                        GoogleProvider({
                            clientId: process.env.NEXT_PUBLIC_GOOGLE_CLIENT_ID as string,
                            clientSecret: process.env.NEXT_PUBLIC_GOOGLE_CLIENT_SECRET as string,
                        }),
                    ]}
                />
           </Typography>
        </Button>
    )
}