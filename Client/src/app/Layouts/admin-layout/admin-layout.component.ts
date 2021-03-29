import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  user: string | undefined;
  logout() {
    // this.accountService.logout().subscribe(success => {
    //   window.location.reload();
    // })
  }

  getUser() {
    // if(this.accountService.getJwtUser()) {
    //   this.user = this.accountService.getJwtUser();
    // }
  }

  constructor(
    // private accountService: AccountService,
  ) { }

  ngOnInit(): void {
    this.getUser();
  }

}
