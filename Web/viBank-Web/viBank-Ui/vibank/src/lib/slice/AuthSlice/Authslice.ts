import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

export interface IAuthState {
    isLoggedIn: boolean;
}

const initialState: IAuthState = {
    isLoggedIn: false,
}
export const authState = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAuthState: (state, action: PayloadAction<IAuthState>) => {
            state.isLoggedIn = action.payload.isLoggedIn;
        },
    },
});

export const { setAuthState } = authState.actions;
export const authReducer = authState.reducer;