import React from "react";
import { IAppLayoutContext, Page } from "./types";

 
 export const PAGES:{[key in Page]: string} = {
     home: "/",
     dashboard: "/",
     profile: "/profile",
     settings: "/settings",
     login: "/login",
     signup: "/signup",
     forgotPassword: "/auth/forgot-password",
     resetPassword: "/auth/reset-password",
     notifications: "/notifications",
     analytics: "/analytics",
     Employee: "/employee",
     Invoices: "/invoices",
     Calender: "/calender",
     Email: "/email",
     Chat: "/chat",
     Reports: "/reports",
     Todos: "/todos",
     Tracking: "/tracking",
     Account: "/account",
     wallet: "/wallet",
     
}
 
const AppLayoutContext = React.createContext<IAppLayoutContext>(
    null as unknown as IAppLayoutContext
)
const useAppLayout = () => {
    return React.useContext(AppLayoutContext)
};


