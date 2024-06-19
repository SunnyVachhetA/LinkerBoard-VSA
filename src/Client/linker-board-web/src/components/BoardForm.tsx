import React, { useState } from "react";
import { IBoard } from "../models/link-board";
import { FieldType } from "../models/field-type";

interface BoardFormProps {
  onSave: (board: IBoard) => void;
  onCancel: () => void;
}

const formFields: FieldType[] = [
  {
    name: "Title",
    isRequired: true,
    type: "text",
    placeholder: "Type title"
  },
  {
    name: "Note",
    isRequired: false,
    type: "textarea",
    placeholder: "Type note"
  }
];

const BoardForm: React.FC<BoardFormProps> = ({ onSave, onCancel }) => {
  const [formData, setFormData] = useState({ title: '', note: '' });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData(prevData => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const newBoard: IBoard = {
      id: 0,
      title: formData.title,
      note: formData.note,
    };
    onSave(newBoard);
    onCancel();
  };

  const handleClose = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    e.preventDefault();
    onCancel();
  }

  return (
    <form className="p-4 md:p-5" onSubmit={handleSubmit}>
      <div className="grid gap-4 mb-4 grid-cols-2">
        {formFields.map((field, index) => (
          <div key={index} className="col-span-2">
            <label htmlFor={field.name} className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
              {field.name}
            </label>
            {field.type === 'text' ? (
              <input
                type="text"
                name={field.name.toLocaleLowerCase()}
                id={field.name}
                className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                placeholder={field.placeholder}
                required={field.isRequired}
                readOnly={field.readonly}
                onChange={handleInputChange}
              />
            ) : (
              <textarea
                id={field.name}
                name={field.name.toLocaleLowerCase()}
                rows={4}
                className="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder={field.placeholder}
                required={field.isRequired}
                readOnly={field.readonly ?? false}
                onChange={handleInputChange}
              />
            )}
          </div>
        ))}
      </div>
      <div className="flex gap-4 justify-end">
        <button
          type="submit"
          className="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
        >
          Add
        </button>
        <button
          type="button"
          className="text-white inline-flex items-center bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-800"
          onClick={handleClose}
        >
          Cancel
        </button>
      </div>
    </form>
  );
};

export default BoardForm;