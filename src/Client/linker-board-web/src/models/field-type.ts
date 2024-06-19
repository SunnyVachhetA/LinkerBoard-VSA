export interface FieldType 
{
    name: string;
    isRequired: boolean;
    type: "number" | "text" | "date" | "textarea";
    placeholder?: string;
    readonly?: boolean,
    value?: string | number | Date
}