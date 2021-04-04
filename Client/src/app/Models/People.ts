import { Role } from "./Role";

export class People{
    id:	number;
    username: string;
    name: string;
    gender: string;
    birthDate: string;
    address: string;
    phone: string;
    registraDate: string;
    role_ID: number;
    status: string;
    role: Role;
    constructor(id: number, username: string, name: string, phone: string, role_ID: number, address: string, birthDate: string, registraDate: string, gender: string, status: string, role: Role)
    {
        this.id = id;
        this.username = username;
        this.name = name;
        this.phone = phone;
        this.role_ID = role_ID;
        this.address = address;
        this.birthDate = birthDate;
        this.registraDate = registraDate;
        this.gender = gender;
        this.status = status;
        this.role = role;
    }
}