import { Branch } from "./branch.model";

export interface  Company {
  id: string | null;
  name: string;
  branch: Branch;
}
