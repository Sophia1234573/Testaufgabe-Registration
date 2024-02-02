import { Company } from "./company.model";

export interface  User {
  id: string | null;
  username: string;
  password: string;
  email: string | null;
  firstName: string;
  lastName: string;
  roles: string[];
  company: Company
}
