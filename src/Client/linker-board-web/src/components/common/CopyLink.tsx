import { IoCopyOutline } from "react-icons/io5";
import { showInfo } from "../../utils/ToastUtil";
import React from "react";

const CopyLink = ({ text } : {text: string}) => {

  const copyLinkToClipboard = (e: React.MouseEvent) => {
    e.preventDefault();
    showInfo('Link copied successfully.');
    navigator.clipboard.writeText(text);
  };

  return (<>
    <IoCopyOutline className="cursor-pointer" onClick={copyLinkToClipboard}/>
  </>);
}

export default CopyLink;