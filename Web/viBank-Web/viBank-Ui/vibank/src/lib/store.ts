import { configureStore,combineReducers} from "@reduxjs/toolkit";
import {  TypedUseSelectorHook, useSelector } from "react-redux";
import { authReducer } from "./slice/AuthSlice/Authslice";

export const makeStore = () => {
    const rootReducer = combineReducers({
        auth: authReducer
    })
    return configureStore({
        reducer: rootReducer,
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
    })
}
export type AppStore = ReturnType<typeof makeStore>
export type RootState = ReturnType<AppStore['getState']>
export type AppDispatch = AppStore['dispatch']
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
