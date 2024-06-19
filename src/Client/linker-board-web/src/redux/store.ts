import { configureStore } from "@reduxjs/toolkit";
import appBoardSlice from "./appBoardSlice";

export const store = configureStore({
  reducer: {
    boardStore: appBoardSlice,
  }
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;