import { ILink } from "../models/link";
import { CiEdit } from "react-icons/ci";
import { MdDeleteOutline } from "react-icons/md";
import { BiLinkExternal } from "react-icons/bi";
import ExternalLink from "./common/ExternalLink";
import CopyLink from "./common/CopyLink";

interface LinkRowProps {
  link: ILink
}

const LinkRow = (props: LinkRowProps) => {
  const formattedUrl = props.link.url.startsWith('http://') 
    || props.link.url.startsWith('https://') 
    ? props.link.url : `https://${props.link.url}`;

  return (<>
    <div className="mb-4 border p-2 rounded bg-white text-black">
      <div className="flex justify-between items-center">
        <span>
          {props.link.title}
        </span>
        <div className="flex space-x-2">
          <CopyLink text={formattedUrl}/>
          <CiEdit className="cursor-pointer" />
          <MdDeleteOutline className="cursor-pointer" />
          <ExternalLink url={formattedUrl}>
            <BiLinkExternal className="cursor-pointer" />
          </ExternalLink>
        </div>
      </div>
    </div>
  </>);
}

export default LinkRow;