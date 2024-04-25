import { configureStore } from "@reduxjs/toolkit";
import {  TypedUseSelectorHook, useSelector } from "react-redux";
import { authReducer } from "./slice/Authslice";

export const makeStore = () => {
    return configureStore({
        reducer:
        {
            auth: authReducer 
                
            },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
    })
}
export type AppStore = ReturnType<typeof makeStore>
export type RootState = ReturnType<AppStore['getState']>
export type AppDispatch = AppStore['dispatch']
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
