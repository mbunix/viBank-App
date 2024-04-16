import { AppProps } from "next/app";
import '../Styles/globals.css'
import '@material-tailwind/react/tailwind.css'
import { Provider } from "react-redux";
import { makeStore } from "@/lib/store";

export default function App({ Component, pageProps }: AppProps) {
    return (
        <Provider store={makeStore()}>
            <Component {...pageProps} />
        </Provider>
    )
}