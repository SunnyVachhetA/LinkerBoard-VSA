import React, { useState, useEffect } from 'react';
import { FaPlus, FaEdit, FaTrashAlt, FaCopy, FaExternalLinkAlt } from 'react-icons/fa';
import Modal from './Modal';
import Tooltip from './Tooltip';

interface SidebarProps {
  isOpen: boolean;
  onClose: () => void;
  board: Board | null;
  onSave: (board: Board) => void;
  onDelete: (id: number) => void;
}

const Sidebar: React.FC<SidebarProps> = ({ isOpen, onClose, board, onSave, onDelete }) => {
  const [editMode, setEditMode] = useState(false);
  const [editedBoard, setEditedBoard] = useState<Board | null>(board);
  const [openLinkIndices, setOpenLinkIndices] = useState<number[]>([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [linkData, setLinkData] = useState<Link>({ title: '', url: '', note: '' });
  const [currentLinkIndex, setCurrentLinkIndex] = useState<number | null>(null);

  useEffect(() => {
    setEditedBoard(board);
    setEditMode(false);
    if (board?.links) {
      setOpenLinkIndices(board.links.map((_, index) => index));
    }
  }, [board]);

  const handleSave = () => {
    if (editedBoard) onSave(editedBoard);
    onClose();
  };

  const handleDelete = () => {
    if (editedBoard && openLinkIndices.length > 0) {
      const updatedLinks = editedBoard.links.filter((_, index) => !openLinkIndices.includes(index));
      setEditedBoard({ ...editedBoard, links: updatedLinks });
      setOpenLinkIndices([]);
    }
  };

  const handleLinkClick = (index: number) => {
    setOpenLinkIndices(prevIndices =>
      prevIndices.includes(index)
        ? prevIndices.filter(i => i !== index)
        : [...prevIndices, index]
    );
  };

  const copyLink = (url: string) => {
    navigator.clipboard.writeText(url);
    alert('Link copied to clipboard');
  };

  const viewLink = (index: number) => {
    if (editedBoard) {
      setLinkData(editedBoard.links[index]);
      setCurrentLinkIndex(index);
      setIsModalOpen(true);
    }
  };

  return (
    <div className={`fixed inset-0 z-50 ${isOpen ? 'block' : 'hidden'}`}>
      <div className="bg-gray-600 bg-opacity-50 absolute inset-0" onClick={onClose}></div>
      <div className="bg-white w-2/6 absolute inset-y-0 right-0 flex flex-col justify-between shadow-lg z-50">
        <div className="p-8 h-full overflow-y-auto">
          <button onClick={onClose} className="absolute top-0 right-0 p-2 text-3xl">&times;</button>
          {editMode ? (
            <>
              <input
                type="text"
                className="border p-2 mb-4 w-full"
                value={editedBoard?.title || ''}
                onChange={(e) => setEditedBoard({ ...editedBoard, title: e.target.value })}
              />
              <div className="flex justify-end">
                <button onClick={handleSave} className="bg-green-500 text-white py-2 px-4 rounded mr-2">Save</button>
                <button onClick={() => setEditMode(false)} className="bg-gray-300 text-gray-700 py-2 px-4 rounded">Cancel</button>
              </div>
            </>
          ) : (
            <>
              <div className="flex justify-between items-center mb-4">
                <h2 className="text-xl font-bold">{editedBoard?.title}</h2>
                <div className="flex space-x-2">
                  <Tooltip text="Add Link">
                    <FaPlus className="text-blue-500 cursor-pointer" onClick={() => console.log('Add Link')} />
                  </Tooltip>
                  <Tooltip text="Edit Board">
                    <FaEdit className="text-blue-500 cursor-pointer" onClick={() => setEditMode(true)} />
                  </Tooltip>
                  <Tooltip text="Delete Board">
                    <FaTrashAlt className="text-red-500 cursor-pointer text-base" onClick={() => onDelete(editedBoard?.id || 0)} />
                  </Tooltip>
                </div>
              </div>
              <div className="mb-4">
                <ul>
                  {editedBoard?.links.map((link, index) => (
                    <li key={index} className="my-2 border p-2 rounded" >
                      <div className="cursor-pointer flex justify-between items-center">
                        <p className="font-bold cursor-pointer" onClick={() => handleLinkClick(index)}>{link.title}</p>
                        <div className="flex space-x-2">
                          <Tooltip text="Copy URL">
                            <FaCopy className="text-yellow-500 cursor-pointer" onClick={() => copyLink(link.url)} />
                          </Tooltip>
                          <Tooltip text="Open in New Tab">
                            <FaExternalLinkAlt className="text-green-500 cursor-pointer" onClick={() => window.open(link.url, '_blank')} />
                          </Tooltip>
                          <Tooltip text="Edit Link">
                            <FaEdit className="text-blue-500 cursor-pointer" onClick={() => viewLink(index)} />
                          </Tooltip>
                        </div>
                      </div>
                      {openLinkIndices.includes(index) && (
                        <div className="border border-gray-300 p-4 mt-4">
                          <div className="mb-2">
                            <p className="text-gray-500">{link.url}</p>
                          </div>
                          <div>
                            <p className="text-gray-500">{link.note}</p>
                          </div>
                        </div>
                      )}
                    </li>
                  ))}
                </ul>
              </div>
            </>
          )}

          <Modal
            isOpen={isModalOpen}
            onClose={() => setIsModalOpen(false)}
            linkData={linkData}
            onSave={(updatedLink: Link) => {
              if (editedBoard && currentLinkIndex !== null) {
                const updatedLinks = [...editedBoard.links];
                updatedLinks[currentLinkIndex] = updatedLink;
                setEditedBoard({ ...editedBoard, links: updatedLinks });
                setIsModalOpen(false);
              }
            }}
          />
        </div>
      </div>
    </div>
  );
};

export default Sidebar;