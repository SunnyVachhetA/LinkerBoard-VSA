import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import IAppBoard from "../models/app-board";
import { IBoard } from "../models/link-board";
import { RootState } from "./store";
import LocalStorageUtil from "../utils/LocalStorageUtil";

type initialAppBoardState = {
  appBoard: IAppBoard;
};

// const initboards: IBoard[] = [
//   {
//     id: 1,
//     title: "Web Searches",
//     links: [
//       { id: 1, title: "Google", note: "", boardId: 1, url: "www.google.com" },
//       {
//         id: 2,
//         title: "Bing",
//         note: "Use search with AI",
//         boardId: 1,
//         url: "www.bing.com",
//       },
//     ],
//   },
//   {
//     id: 2,
//     title: "React sites",
//     links: [
//       {
//         id: 1,
//         title: "React Dev",
//         note: "",
//         boardId: 2,
//         url: "https://react.dev/",
//       },
//       {
//         id: 2,
//         title: "Icons Set",
//         note: "",
//         boardId: 2,
//         url: "https://react-icons.github.io/react-icons/",
//       },
//     ],
//   },
// ];

// const appBoard: IAppBoard = {
//   boards: initboards,
//   boardCount: initboards.length,
//   linkCount: initboards.reduce((total, board) => total + (board.links?.length ?? 0), 0)
// };

const localAppBoard = LocalStorageUtil.getItem("store") as IAppBoard;
const appBoard = localAppBoard;
const initialState: initialAppBoardState = {
  appBoard
};

const AppBoardSlice = createSlice({
  name: "app-board",
  initialState: initialState,
  reducers: {
    addNewBoard: (state, action: PayloadAction<IBoard>) => {
      action.payload.id = state.appBoard.boardCount + 1;
      state.appBoard.boards.push(action.payload);
      state.appBoard.boardCount++;
      state.appBoard.linkCount = action.payload.links?.length ?? 0;
      
      LocalStorageUtil.setItem("store", state.appBoard);
    },
    updateBoard: (state, action: PayloadAction<IBoard>) => {
      console.log(state);
      const { payload: { id, title, note } } = action;

      state.appBoard.boards = state.appBoard.boards
        .map(board => board.id === id ? { ...board, title, note } : board);
    }
  }
});


export default AppBoardSlice.reducer;
export const { addNewBoard, updateBoard } = AppBoardSlice.actions;
export const initAppBoards = (state: RootState) => state.boardStore;