import React, { ReactNode } from 'react';

interface TooltipProps {
  text: string;
  children: ReactNode;
}

const Tooltip: React.FC<TooltipProps> = ({ text, children }) => {
  return (
    <div className="relative group">
      {children}
      <div className="absolute bottom-full left-1/2 transform -translate-x-1/2 mb-2 w-max p-2 bg-gray-700 text-white text-xs rounded opacity-0 group-hover:opacity-100 transition-opacity duration-300">
        {text}
      </div>
    </div>
  );
};

export default Tooltip;
