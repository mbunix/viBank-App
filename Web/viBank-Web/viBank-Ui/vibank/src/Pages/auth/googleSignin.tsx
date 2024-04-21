import React from "react";
import { Button, IconButton, Typography } from "@material-tailwind/react";
import { signIn } from "next-auth/next-auth/client";
import GoogleProvider from "next-auth/providers/google";

export default function GoogleSignIn({
    onSuccess,
    onError
}: {
    onSuccess: () => void;
    onError: (error: any) => void;
}) {
    const handleGoogleLogin = async () => {
        try {
            await signIn("google"); // Use signIn function from next-auth/client
            onSuccess(); // Call the onSuccess callback upon successful authentication
        } catch (error) {
            onError(error); // Call the onError callback with the error object if authentication fails
        }
    };

    return (
        <Button
            variant="gradient"
            size="sm"
            fullWidth
            className="mb-2"
            onClick={handleGoogleLogin} // Add onClick event handler to trigger the handleGoogleLogin function
        >
            <Typography variant="small" color="white" className="font-medium">
                <IconButton variant="text">
                    <img
                        src="/icons8-google.svg" // Provide the correct path to the Google logo image
                        alt="Google Logo"
                        className="w-4 mr-2"
                    />
                    Sign in with Google
                </IconButton>
            </Typography>
        </Button>
    );
}
