import React,{ useState, useEffect } from "react";
import { Button, IconButton, Typography } from "@material-tailwind/react";
import NextAuth from "next-auth/next";
import GoogleProvider from "next-auth/providers/google";
export default function GoogleSignIn({ onSuccess, onError }: { onSuccess: () => void; onError: (error: any) => void }) {
    const handleGoogleLogin = async () => {
        try {
          
            }
            await NextAuth.signIn("google");
            onSuccess(); // Call the onSuccess callback upon successful authentication
        } catch (error) {
            onError(error); // Call the onError callback with the error object if authentication fails
        }
    };
    return (
        <Button variant="gradient" size="sm" fullWidth className="mb-2" placeholder={"sign in with google"}>
            <Typography variant="small" color="white" className="font-medium" placeholder={"google"}>
                <IconButton variant= "text" placeholder={"google"}>
                    <img src ="public/icons8-google.svg" alt="logo" className="w-4"/>
                        Sign in with Google
                </IconButton>
           </Typography>
        </Button>
    )
}