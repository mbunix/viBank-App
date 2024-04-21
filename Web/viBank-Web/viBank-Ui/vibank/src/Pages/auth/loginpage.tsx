import React from 'react';
import { Card, Typography } from '@material-tailwind/react';
import GoogleSignIn from './googleSignin';
import MicrosoftSignIn from './MicrosoftLogin';

export default function LoginPage({ onClose } : { onClose: () => void }) {
    const handleLoginSuccess = () => {
        onClose(); // Close the login page upon successful authentication
    };

    return ( 
        <div className="flex h-1/4 w-1/4 ">
            {/* Right side: Login form */}
            <div className="w-1/2 flex justify-center items-center">
                <Card color="transparent" shadow={false} placeholder={"login"}>
                    <Typography variant="h5" color="blue-gray" className="mb-2" placeholder={"login"}>
                        Hi, Welcome Back!
                    </Typography>
                    <Typography color="gray" className="mt-1 font-normal" placeholder={"login"}>
                        Login to your account and enjoy.
                         <MicrosoftSignIn onSuccess={handleLoginSuccess} onError={console.error} />
                    </Typography>
                </Card>
            </div>
        </div>
    );
}
