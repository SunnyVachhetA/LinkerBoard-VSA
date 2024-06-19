import { TypedUseSelectorHook, useSelector } from "react-redux";
import LinkBoard from "../components/LinkBoard";
import TopBar from "../components/TopBar";
import { IBoard } from "../models/link-board";
import { RootState } from "../redux/store";

const LinkBoardPage = () => {

  const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
  const appBoards = useAppSelector(state => state.boardStore.appBoard.boards);

  const boardMap = appBoards.map((board: IBoard) => {
    return <LinkBoard key={board.id} linkBoard={board} />;
  });

  return (
    <>
      <TopBar />
      <div className="p-4 overflow-auto grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        {boardMap}
      </div>
    </>
  );
};

export default LinkBoardPage;
