import { Card, Typography } from "@material-tailwind/react"
import React from "react"
import GoogleSignIn from "./googleSignin"
export default function Index() {
    return (
        <Card color="transparent" shadow={false} placeholder={"login"}>
            <img src="public/dark-logo.svg" alt="logo" className="w-32" />
            <Typography variant="h5" color="blue-gray" className="mb-2" placeholder={"login"}>
                Hi, Welcome Back!
                <Typography color="gray" className="mt-1 font-normal" placeholder={"login"}>
                    Login to your account and  enjoy 
                    <GoogleSignIn />
                </Typography>
            </Typography>
        </Card>
  )  
}