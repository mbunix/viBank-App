import React from "react";
import { ListItem } from "@material-tailwind/react";

 
export type Page =
    | "home"
    | "dashboard"
    | "profile"
    | "settings"
    | "login"
    | "signup"
    | "forgotPassword"
    | "resetPassword"
    | "notifications"
    | "analytics"
    | "Employee"
    | "Invoices"
    | "Calender"
    | "Email"
    | "Chat"
    | "Reports"
    | "Todos"
    | "Tracking"
    | "Account"
    | "wallet";

export type ScreenSize = "sm" | "md" | "lg" | "xl";

export type Theme = "light" | "dark";
export interface IAppLayoutContext {
    isSmallScreen: boolean;
    onSideBarClick: (action: "maximize" | "minimize") => void;
    navItems: {
        title: string;
        link: string;
        icon: React.ReactNode;
        subNavItems?: {
            title: string;
            link: string;
            icon: React.ReactNode;
        }[];
    }
}