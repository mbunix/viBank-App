import { User } from "@/Models/UserModel";
import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

export interface IauthState {
    isLoggedIn: boolean;
}

const initialState: IauthState = {
    isLoggedIn: false,
}
export const authState = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAuthState: (state, action: PayloadAction<IauthState>) => {
            state.isLoggedIn = action.payload.isLoggedIn;
        },
    },
});

export const { setAuthState } = authState.actions;
export const authReducer = authState.reducer;