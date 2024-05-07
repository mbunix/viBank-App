import { AppProps } from "next/app";
import "../Styles/globals.css";
import 'primeicons/primeicons.css';
import { Provider } from "react-redux";
import { makeStore } from "@/lib/store";
import RootLayout from "@/Components/Layout";
import DashboardLayout from "@/Components/DashboardLayout";
import { SessionProvider } from 'next-auth/react';
import { usePathname } from "next/navigation";
import { PrimeReactProvider } from 'primereact/api';
export default function App({ Component, pageProps }: AppProps) {
    const pathName = usePathname();
    const isLoggedIn = true;
    const value = {
        cssTransition: true
    };
    const isDashboardRoute = pathName.includes("dashboard");
    return (
        <Provider store={makeStore()}>
            {isDashboardRoute && isLoggedIn ? (
                <DashboardLayout>
                    <PrimeReactProvider {...value}>
                        <SessionProvider session={pageProps.session}>
                            <Component {...pageProps} />
                        </SessionProvider>
                    </PrimeReactProvider>
                </DashboardLayout>
            ) : (
                <RootLayout>
                    <PrimeReactProvider>
                       <SessionProvider session={pageProps.session}>
                            <Component {...pageProps} />
                        </SessionProvider>
                    </PrimeReactProvider>
                </RootLayout>
            )}
        </Provider>
    )
}