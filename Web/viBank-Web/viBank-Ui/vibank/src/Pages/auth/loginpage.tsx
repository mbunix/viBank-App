import React from 'react';
import { Card, Typography } from '@material-tailwind/react';
import GoogleSignIn from './googleSignin';
import { MapsMapper } from './map';
import MicrosoftSignIn from './MicrosoftLogin';

export default function Index() {
    return (
        <div className="flex h-screen">
            {/* Left side: MapsMapper */}
            <div className="w-1/2">
                <MapsMapper />
            </div>

            {/* Right side: Login form */}
            <div className="w-1/2 flex justify-center items-center">
                <Card color="transparent" shadow={false} placeholder={"login"}>
                    <Typography variant="h5" color="blue-gray" className="mb-2" placeholder={"login"}>
                        Hi, Welcome Back!
                    </Typography>
                    <Typography color="gray" className="mt-1 font-normal" placeholder={"login"}>
                        Login to your account and enjoy.
                        <GoogleSignIn /> or <MicrosoftSignIn/>
                    </Typography>

                    <form className="max-w-screen-lg mt-8 mb-2 w-80 sm:w-96">
                        {/* Email and password inputs */}
                        <div className="flex flex-col gap-6 mb-1">
                            <div>
                                <label className="block font-semibold leading-relaxed text-blue-gray-900">
                                    Your Email
                                </label>
                                <input
                                    placeholder="name@mail.com"
                                    className="peer h-full w-full rounded-md border border-blue-gray-200 bg-transparent px-3 py-3 font-sans text-sm font-normal text-blue-gray-700 transition-all placeholder:text-blue-gray-500 focus:border-gray-900 focus:outline-0"
                                />
                            </div>
                            <div>
                                <label className="block font-semibold leading-relaxed text-blue-gray-900">
                                    Password
                                </label>
                                <input
                                    type="password"
                                    placeholder="********"
                                    className="peer h-full w-full rounded-md border border-blue-gray-200 bg-transparent px-3 py-3 font-sans text-sm font-normal text-blue-gray-700 transition-all placeholder:text-blue-gray-500 focus:border-gray-900 focus:outline-0"
                                />
                            </div>
                        </div>

                        {/* Remember me checkbox */}
                        <div className="flex items-center mb-4">
                            <input
                                type="checkbox"
                                className="mr-2"
                                id="remember"
                            />
                            <label htmlFor="remember">
                                I agree to the&nbsp;
                                <a href="/terms&conditions" className="font-medium text-gray-900">
                                    Terms and Conditions
                                </a>
                            </label>
                        </div>

                        {/* Submit button */}
                        <button
                            type="button"
                            className="w-full mt-6 py-3 rounded-lg bg-gray-900 text-white uppercase font-bold"
                        >
                            Sign Up
                        </button>

                        {/* Sign-in link */}
                        <p className="text-center mt-4">
                            Already have an account?
                            <a href="/sign-in" className="text-gray-900 font-medium">
                                &nbsp;Sign In
                            </a>
                        </p>
                    </form>
                </Card>
            </div>
        </div>
    );
}
