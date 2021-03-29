export class Account {
    id: number;
    username: string;
    password: string;
    active = false;
    token: string;
    roles: string;
    refreshToken: string;
    constructor(id: number, username: string, password: string, token: string, roles: string, refreshToken: string){
        this.id = id;
        this.username = username;
        this.password = password;
        this.token = token;
        this.roles = roles;
        this.refreshToken = refreshToken;
    }
}