import { IBoard } from "../models/link-board";
import { RiAddBoxFill } from "react-icons/ri";
import { RiEditBoxFill } from "react-icons/ri";
import { RiDeleteBin5Fill } from "react-icons/ri";
import { ILink } from "../models/link";
import { MdOutlineManageSearch } from "react-icons/md";
import LinkRow from "./LinkRow";
import { useState } from "react";
import PopUpModal from "./common/Pop-Up-Modal";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../redux/store";
import { addNewBoard } from "../redux/appBoardSlice";
import Modal from "./common/Modal";
import BoardForm from "./BoardForm";

interface LinkBoardProps {
  linkBoard: IBoard;
}

const LinkBoard = (props: LinkBoardProps) => {
  const [isDeleteModalOpen, setDeleteModal] = useState(false);
  const [isAddNewBoard, setAddNewBoard] = useState(false);
  const useAppDispatch = () => useDispatch<AppDispatch>();
  const dispatch = useAppDispatch();

  const boardLinksMap = props.linkBoard.links?.map((link: ILink) => {
    return <LinkRow link={link} key={link.id} />;
  });

  const openDeleteModal = () => setDeleteModal(true);
  const closeDeleteModal = () => setDeleteModal(false);

  const addBoardToStore = () => {
    // const newBoard: IBoard = {
    //   id: 3,
    //   title: "By Store",
    //   links: [],
    // };
    // const upBoard: IBoard = {
    //   id: 2,
    //   title: "React Site + Store",
    //   links: [],
    // };
    // dispatch(addNewBoard(newBoard));
    // dispatch(updateBoard(upBoard));
    setAddNewBoard(true);
  };

  const closeAddNewBoard = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    e.preventDefault();
    setAddNewBoard(false);
  }
  
  const saveNewBoard = (board: IBoard) => {
    dispatch(addNewBoard(board));
  }

  return (
    <>
      <div className="border p-4 bg-white rounded shadow-sm hover:shadow-lg transition-shadow flex flex-col">
        <div className="flex justify-between items-center mb-4">
          <h2 className="font-bold text-xl flex-grow">
            {props.linkBoard.title}
          </h2>
          <div className="flex space-x-2">
            <MdOutlineManageSearch className="cursor-pointer" />
            <RiAddBoxFill
              className="text-green-500 cursor-pointer"
              onClick={addBoardToStore}
            />
            <RiEditBoxFill className="text-blue-500 cursor-pointer" />
            <RiDeleteBin5Fill
              className="text-red-500 cursor-pointer"
              onClick={openDeleteModal}
            />
          </div>
        </div>
        <div className="flex-1 overflow-auto mb-4 max-h-48 p-4">
          {boardLinksMap}
        </div>
      </div>
      <PopUpModal
        isOpen={isDeleteModalOpen}
        onClose={closeDeleteModal}
        onSubmit={() => console.log("submit")}
        note={"Are you sure"}
      ></PopUpModal>
      <Modal
        isOpen={isAddNewBoard}
        onClose={closeAddNewBoard}
        title={"Add new Board"}
      >
        <BoardForm onSave={(b) => saveNewBoard(b)} 
          onCancel={() => setAddNewBoard(false)} />
      </Modal>
    </>
  );
};

export default LinkBoard;
