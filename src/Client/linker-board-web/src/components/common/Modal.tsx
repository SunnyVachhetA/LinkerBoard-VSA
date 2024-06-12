import React from 'react';

interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSave: (linkData: LinkData) => void;
  linkData: LinkData;
  setLinkData: React.Dispatch<React.SetStateAction<LinkData>>;
}

interface LinkData {
  title: string;
  url: string;
  note: string;
}

const Modal: React.FC<ModalProps> = ({ isOpen, onClose, onSave, linkData, setLinkData }) => {
  if (!isOpen) return null;

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setLinkData(prevData => ({ ...prevData, [name]: value }));
  };

  const handleSave = () => {
    onSave(linkData);
  };

  return (
    <div className="fixed inset-0 flex items-center justify-center z-50">
      <div className="absolute inset-0 bg-gray-800 bg-opacity-75"></div>
      <div className="bg-white p-6 rounded shadow-lg w-96 relative z-10">
        <h2 className="text-xl font-bold mb-4">Link Details</h2>
        <label className="block mb-2">
          Title:
          <input
            type="text"
            name="title"
            value={linkData.title}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
          />
        </label>
        <label className="block mb-2">
          URL:
          <input
            type="text"
            name="url"
            value={linkData.url}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
          />
        </label>
        <label className="block mb-4">
          Note:
          <textarea
            name="note"
            value={linkData.note}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
          ></textarea>
        </label>
        <div className="flex justify-end space-x-2">
          <button
            onClick={onClose}
            className="px-4 py-2 bg-gray-300 text-gray-800 rounded hover:bg-gray-400 focus:outline-none focus:bg-gray-400"
          >
            Cancel
          </button>
          <button
            onClick={handleSave}
            className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 focus:outline-none focus:bg-blue-600"
          >
            Save
          </button>
        </div>
      </div>
    </div>
  );
};

export default Modal;