import { IBoard } from "./link-board";

interface IAppBoard {
  boards: IBoard[];
  boardCount: number;
  linkCount: number;
}

export default IAppBoard;