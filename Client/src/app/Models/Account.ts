export class Account {
    id: number;
    username: string;
    name: string;
    token: string;
    roles: string;
    refreshToken: string;
    constructor(id: number, username: string, name: string, token: string, roles: string, refreshToken: string){
        this.id = id;
        this.username = username;
        this.name = name;
        this.token = token;
        this.roles = roles;
        this.refreshToken = refreshToken;
    }
}