import React, { useState } from 'react';
import { useFormik } from 'formik';
import * as Yup from 'yup';
import { useRouter } from 'next/router';
function SignUpPage({ onSubmit, onClose }: any) {
    const [showPassword, setShowPassword] = useState(false);
    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            remember: false,
        },
        validationSchema: Yup.object({
            email: Yup.string().email('Invalid email address').required('Required'),
            password: Yup.string().min(8, 'Password must be at least 8 characters').required('Required'),
            remember: Yup.boolean(),
        }),
        onSubmit: values => {
            onSubmit(values);
            onClose(); // Close the sign-up page upon successful submission
        },
    });

    return (
        <div>
            <form onSubmit={formik.handleSubmit} className="max-w-screen-lg mt-8 mb-2 w-80 sm:w-96">
                {/* Email input */}
                <div className="flex flex-col gap-6 mb-1">
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
                            <div className="text-red-500">{formik.errors.email}</div>
                        ) : null}
                    </div>

                    {/* Password input */}
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
                            <div className="text-red-500">{formik.errors.password}</div>
                        ) : null}
                    </div>
                </div>

                {/* Remember me checkbox */}
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
                        <a href="/terms&conditions" className="font-medium text-gray-900">
                            Terms and Conditions
                        </a>
                    </label>
                </div>

                {/* Submit button */}
                <button type="submit" className="w-full mt-6 py-3 rounded-lg bg-gray-900 text-white uppercase font-bold">
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
        </div>
    );
}

export default SignUpPage;
