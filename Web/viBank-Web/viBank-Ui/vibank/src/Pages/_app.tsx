import { AppProps } from "next/app";
import '../Styles/globals.css'
// import '@material-tailwind/react/tailwind.css'
import { Provider } from "react-redux";
import { makeStore } from "@/lib/store";
import RootLayout from "@/Components/Layout";
import DashboardLayout from "@/Components/DashboardLayout";
import { usePathname } from "next/navigation";
export default function App({ Component, pageProps }:AppProps) {
  const pathName = usePathname();
  const isLoggedIn = true
  const isDashboardRoute =  pathName.includes("dashboard");
  return(
    <Provider store={makeStore()}>
    {isDashboardRoute && isLoggedIn ? (
        <DashboardLayout>
            <Component {...pageProps} />
        </DashboardLayout>
    ) : (
        <RootLayout>
            <Component {...pageProps} />
        </RootLayout>
    )}
</Provider>
  )
}