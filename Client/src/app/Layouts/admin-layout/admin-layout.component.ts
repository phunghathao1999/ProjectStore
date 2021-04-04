import { Component, OnInit } from '@angular/core';
import { AccountServer } from 'src/app/Server/account.server';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  user!: string | null;
  logout() {
    this.accountServer.logout().subscribe(success => {
      window.location.reload();
    })
  }

  getUser() {
    if(this.accountServer.getJwtUser()) {
      this.user = this.accountServer.getJwtUser();
    }
  }

  constructor(
    private accountServer: AccountServer,
  ) { }

  ngOnInit(): void {
    this.getUser();
  }

}
