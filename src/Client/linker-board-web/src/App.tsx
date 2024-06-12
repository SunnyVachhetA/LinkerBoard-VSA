import React, { useState } from 'react';
import { FaTrash, FaPlus, FaCopy, FaEdit } from 'react-icons/fa';
import Modal from './components/common/Modal';
import Footer from './components/Footer';
import Tooltip from './components/common/Tooltip';
import Header from './components/Header';
import Sidebar from './components/common/Sidebar';

const App: React.FC = () => {
  const [boards, setBoards] = useState<Board[]>([
    { id: 1, title: 'Board Title 1', links: [{ title: 'Link 1', url: 'https://example.com', note: '' }, { title: 'Link 2', url: 'https://example.com', note: '' }] },
    { id: 2, title: 'Board Title 2', links: [{ title: 'Link 1', url: 'https://example.com', note: '' }, { title: 'Link 2', url: 'https://example.com', note: '' }] }
  ]);

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isLinkModalOpen, setIsLinkModalOpen] = useState(false);
  const [currentBoardId, setCurrentBoardId] = useState<number | null>(null);
  const [linkData, setLinkData] = useState<Link>({ title: '', url: '', note: '' });
  const [currentLink, setCurrentLink] = useState<{ boardId: number, link: Link, index: number } | null>(null);
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);
  const [selectedBoard, setSelectedBoard] = useState<Board | null>(null);

  const addNewBoard = () => {
    const newBoard: Board = {
      id: boards.length + 1,
      title: `Board Title ${boards.length + 1}`,
      links: []
    };
    setBoards([...boards, newBoard]);
  };

  const deleteBoard = (id: number) => {
    setBoards(boards.filter(board => board.id !== id));
    setIsSidebarOpen(false);
  };

  const addNewLink = (boardId: number) => {
    setCurrentBoardId(boardId);
    setLinkData({ title: '', url: '', note: '' });
    setIsModalOpen(true);
  };

  const saveLink = (linkData: Link) => {
    setBoards(boards.map(board => 
      board.id === currentBoardId ? { ...board, links: [...board.links, linkData] } : board
    ));
    setIsModalOpen(false);
  };

  const updateLink = (boardId: number, index: number, updatedLink: Link) => {
    setBoards(boards.map(board =>
      board.id === boardId ? {
        ...board,
        links: board.links.map((link, i) => i === index ? updatedLink : link)
      } : board
    ));
    setIsLinkModalOpen(false);
  };

  const deleteLink = (boardId: number, linkIndex: number) => {
    setBoards(boards.map(board => 
      board.id === boardId ? { ...board, links: board.links.filter((_, index) => index !== linkIndex) } : board
    ));
  };

  const viewLink = (boardId: number, link: Link, index: number) => {
    setCurrentLink({ boardId, link, index });
    setIsLinkModalOpen(true);
  };

  const copyLink = (url: string) => {
    navigator.clipboard.writeText(url);
    alert('Link copied to clipboard');
  };

  const openSidebar = (board: Board) => {
    setSelectedBoard(board);
    setIsSidebarOpen(true);
  };

  const saveBoard = (board: Board) => {
    setBoards(boards.map(b => b.id === board.id ? board : b));
    setIsSidebarOpen(false);
  };

  return (
    <div className="flex flex-col h-screen bg-gray-100">
      <Header />

      <div className="flex-1 flex flex-col overflow-hidden">
        <div className="bg-gray-200 p-4 flex items-center justify-between">
          <button
            onClick={addNewBoard}
            className="bg-green-500 text-white py-2 px-4 rounded"
          >
            New Board
          </button>
          <input 
            type="text" 
            placeholder="Search" 
            className="border p-2 rounded w-1/3"
          />
        </div>

        <div className="p-4 overflow-auto grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {boards.map(board => (
            <div key={board.id} className="border p-4 bg-white rounded shadow-sm hover:shadow-lg transition-shadow flex flex-col">
              <div className="flex justify-between items-center mb-4">
                <h2 className="font-bold text-xl flex-grow">{board.title}</h2>
                <div className="flex space-x-2">
                  <Tooltip text="Add Link">
                    <FaPlus 
                      className="text-green-500 cursor-pointer" 
                      onClick={() => addNewLink(board.id)} 
                    />
                  </Tooltip>
                  <Tooltip text="Edit Board">
                    <FaEdit 
                      className="text-blue-500 cursor-pointer" 
                      onClick={() => openSidebar(board)}
                    />
                  </Tooltip>
                  <Tooltip text="Delete Board">
                    <FaTrash 
                      className="text-red-500 cursor-pointer text-sm" 
                      onClick={() => deleteBoard(board.id)} 
                    />
                  </Tooltip>
                </div>
              </div>
              <div className="flex-1 overflow-auto mb-4 max-h-48 p-4">
                {board.links.map((link, index) => (
                  <div key={index} className="mb-4 border p-2 rounded bg-white text-black">
                    <div className="flex justify-between items-center">
                      <span className="cursor-pointer" onClick={() => viewLink(board.id, link, index)}>{link.title}</span>
                      <div className="flex space-x-2">
                        <Tooltip text="Copy Link">
                          <FaCopy 
                            className="text-yellow-500 cursor-pointer" 
                            onClick={() => copyLink(link.url)} 
                          />
                        </Tooltip>
                        <Tooltip text="Delete Link">
                          <FaTrash 
                            className="text-red-500 cursor-pointer text-sm" 
                            onClick={() => deleteLink(board.id, index)} 
                          />
                        </Tooltip>
                        <Tooltip text="Edit Link">
                          <FaEdit 
                            className="text-blue-500 cursor-pointer" 
                            onClick={() => viewLink(board.id, link, index)} 
                          />
                        </Tooltip>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          ))}
        </div>
      </div>

      <Footer />

      <Modal 
        isOpen={isModalOpen} 
        onClose={() => setIsModalOpen(false)} 
        onSave={saveLink}
        linkData={linkData}
        setLinkData={setLinkData}
      />

      {currentLink && (
        <Modal 
          isOpen={isLinkModalOpen} 
          onClose={() => setIsLinkModalOpen(false)} 
          onSave={(updatedLink: Link) => updateLink(currentLink.boardId, currentLink.index, updatedLink)}
          linkData={currentLink.link}
          setLinkData={(updatedLink: Link) => setCurrentLink({ ...currentLink, link: updatedLink })}
        />
      )}

      <Sidebar 
        isOpen={isSidebarOpen} 
        onClose={() => setIsSidebarOpen(false)} 
        board={selectedBoard} 
        onSave={saveBoard} 
        onDelete={deleteBoard} 
      />
    </div>
  );
}

export default App;
