import { ILink } from "./link";

export interface IBoard {
  id: number;
  title: string;
  links?: ILink[];
  note?: string
}