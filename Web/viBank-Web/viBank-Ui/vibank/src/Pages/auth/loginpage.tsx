import React from 'react';
import { Card, Typography } from '@material-tailwind/react';
import { useSession, signIn } from 'next-auth/react'
import { useRouter } from 'next/router'
import { Image } from 'primereact/image';
import { Button } from 'primereact/button';
export default function LoginPage() {
    const { data: session } = useSession();
    const router = useRouter();
    if (session) {
        router.push('/dashboard')
        return (
            <>
                You are already logged in as {session.user?.email}
            </>
        )
    }
    return ( 
        <div className="h-50 w-50 ">
            <div className="flex justify-center align-center border-2 border-gray-500">
                <Card color="transparent" shadow={false} placeholder={"login"}>
                    <Typography variant="h5" color="blue-gray" className="mb-2" placeholder={"login"}>
                        Hi, Welcome Back!
                    </Typography>
                    <Typography color="gray" className="mt-1  justify-around font-normal flex p-3" placeholder={"login"}>
                        Login to your account and enjoy.
                </Typography>
                <div className='flex justify-around'>
                <Button className="w-50 mt-6 py-3 rounded-lg bg-gray-300 text-gray-900 font-medium" onClick={(e) => { e.preventDefault(); signIn('google')}}>
                    <Image src='icons8-google-48.png' alt="google" />
                    Login with google
                </Button>
                or 
                <Button className="w-50 mt-6 py-3 rounded-lg bg-gray-300 text-gray-900 font-medium " onClick={() => signIn('microsoft')}>
                    <Image  src='icons8-microsoft-48.png' alt="microsoft" />
                    Login with microsoft
                    </Button>
                </div>
                </Card>
            </div>
        </div>
    );
}
