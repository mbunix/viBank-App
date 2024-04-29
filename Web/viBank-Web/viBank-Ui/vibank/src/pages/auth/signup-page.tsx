import React, { useEffect, useState } from 'react';
import { useFormik } from 'formik';
import * as Yup from 'yup';
import { useRouter } from 'next/router';
import { createUser, login } from '@/Services/auth/auth.service';
import { getToken } from '@/constants/auth';
import { Image } from 'primereact/image';
import CircularProgress from '@mui/material/CircularProgress';
import Button from '@mui/material/Button';
function SignUpPage() {
    const router = useRouter();
    const [loading, setLoading] = useState(true)
    const formik = useFormik({
        initialValues: {
            username: '',
            email: '',
            password: '',
            remember: false,
        },
        validationSchema: Yup.object({
            email: Yup.string().email('Invalid email address').required('Required'),
            password: Yup.string().min(8, 'Password must be at least 8 characters').required('Required'),
            remember: Yup.boolean(),
        }),
        onSubmit: async (values, { setSubmitting }) => {
            
            try {
                const res: any = await createUser(values);
                let token = res.data?.token;
                if (token) {
                    const url = router.query?.redirect as string || '/dashboard';
                    router.push(url);
                }
            } catch (error) {
                console.log(error);
            } finally {
                setSubmitting(false);
            }
        },
    });
    useEffect(() => {
        if (getToken()) {
            router.push('/dashboard');
        } else {
            setLoading(false)
        }
    }, [router])

    return (
        <div>
            <form  className="max-w-screen-lg mt-8 mb-2 w-80 sm:w-96">
                <div className="flex flex-col gap-6 mb-1">
                    <div className="flex justify-center align-center">
                        <p className="text-2xl text-neutral-950 font-medium">Welcome to cardo Mobile Finance </p>
                    </div >
                    <div className="flex justify-center align-center">
                        <Image src="dark-logo.svg" alt="Logo" className="w-40 " />
                    </div>
                    <div>
                        <label className="block font-semibold leading-relaxed text-blue-gray-900">
                            Your Email
                        </label>
                        <input
                            type="text"
                            name="email"
                            placeholder="name@mail.com"
                            className="peer h-full w-full rounded-md border border-blue-gray-200 bg-transparent px-3 py-3 font-sans text-sm font-normal text-blue-gray-700 transition-all placeholder:text-blue-gray-500 focus:border-gray-900 focus:outline-0"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.email}
                        />
                        {formik.touched.email && formik.errors.email ? (
                            <div className="text-red-500">
                                {
                                    formik.errors.email as string
                                }
                            </div>
                        ) : null}
                    </div>
                    <div>
                        <label className="block font-semibold leading-relaxed text-blue-gray-900">
                            Password
                        </label>
                        <input
                            type="password"
                            name="password"
                            placeholder="********"
                            className="peer h-full w-full rounded-md border border-blue-gray-200 bg-transparent px-3 py-3 font-sans text-sm font-normal text-blue-gray-700 transition-all placeholder:text-blue-gray-500 focus:border-gray-900 focus:outline-0"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.password}
                        />
                        {formik.touched.password && formik.errors.password ? (
                            <div className="text-red-500">{
                                formik.errors.password as string
                            }</div>
                        ) : null}
                    </div>
                    <div className="flex items-center mb-4">
                        
                        <input
                            type="checkbox"
                            id='username'
                            name="username"
                            className="mr-2"
                            onChange={formik.handleChange}
                            value={formik.values.email.split('@')[0]}
                        />
                        <label htmlFor="username" className=" font-medium  text-gray-900"> Confirm your Email as Your Username </label>
                    </div>
                </div>
                <div className="flex items-center mb-4">
                    <input
                        type="checkbox"
                        id="remember"
                        name="remember"
                        className="mr-2"
                        checked={formik.values.remember}
                        onChange={formik.handleChange}
                    />
                    <label htmlFor="remember">
                        I agree to the&nbsp;
                    <a href ="/terms&conditions" className="font-medium text-gray-900">Terms and Conditions</a>
                    </label>
                </div>
                <Button type="submit" className="w-full mt-6 py-3 rounded-lg bg-gray-900 text-white uppercase font-bold" disabled={formik.isSubmitting} onClick={()=>formik.handleSubmit}>
                    Sign Up
                </Button>
                    <p className="text-center mt-4">Already have an account? <a href="/sign-in" className = "text-gray-900 font-medium"> &nbsp;Sign In here</a>
                </p>
            </form>
             {loading && <CircularProgress />}
        </div>
       
    );
}

export default SignUpPage;
