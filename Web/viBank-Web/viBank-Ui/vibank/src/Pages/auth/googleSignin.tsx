import React,{ useState, useEffect } from "react";
import { Button, IconButton, Typography } from "@material-tailwind/react";

export default function GoogleSignIn() {
    const [isGoogleSignIn, setIsGoogleSignIn] = useState(false);
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