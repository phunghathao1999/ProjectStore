import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from 'src/app/Models/Account';

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
    const user: Account = { username, password } as Account;
    // this.AccountService.login(user).subscribe(success => {
    //   if(success) {
    //     const redirectUrl = '/admin/timework';

    //     const navigationExtras: NavigationExtras = {
    //       queryParamsHandling: 'preserve',
    //       preserveFragment: true
    //     };

    //     this.router.navigate([redirectUrl], navigationExtras);
    //   }
    // });
  }

  constructor(
    private formBuilder: FormBuilder,
    // private AccountService: AccountService,
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
