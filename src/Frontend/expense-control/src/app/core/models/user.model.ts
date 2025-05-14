import { IIdentificationType } from "./identificationtype.model";

export interface IUser {
  id?: string;
  name: string;
  middleName?: string;
  lastName: string;
  SurName?: string;
  identificationTypeId: string;
  identificationNumber: string;
  birthDate: Date;
  address: string;
  contact: string;
}
