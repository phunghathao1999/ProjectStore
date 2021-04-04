import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { Account } from 'src/app/Models/Account';
import { Login } from 'src/app/Models/Login';
import { AccountServer } from 'src/app/Server/account.server';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin!: FormGroup;
  submittedLogin = true;

  login(){
    const username = this.email?.value;
    const password = this.password?.value;
    const user: Login = { username, password } as Login;
    this.accountServer.login(user).subscribe(success => {
      if(success) {
        const redirectUrl = '/admin/dashboard';
        const navigationExtras: NavigationExtras = {
          queryParamsHandling: 'preserve',
          preserveFragment: true
        };

        this.router.navigate([redirectUrl], navigationExtras);
      }
    });
  }

  constructor(
    private formBuilder: FormBuilder,
    private accountServer: AccountServer,
    private router: Router,
    ) { }

  ngOnInit(): void {

    this.formLogin = this.formBuilder.group({
      email: ['',[Validators.required, Validators.email]],
      password: ['',[Validators.required]]
    });
  }
  get email() {
    return this.formLogin.get('email');
  }
  get password() {
    return this.formLogin.get('password');
  }

}
