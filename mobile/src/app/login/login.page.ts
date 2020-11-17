import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  formGroup: FormGroup;
  accessToken: string;

  constructor(private accountService: AccountService, private formBuilder: FormBuilder, public router: Router) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', Validators.required]
    });
  }

  login() {
    this.accountService.login(this.formGroup.value.email, this.formGroup.value.senha).subscribe((response: any) => {

      const responseToken = response.data;
      console.log(response);

      if (responseToken) {
        this.accessToken = responseToken.acessToken;

        localStorage.setItem('currentUser', JSON.stringify({
          id: responseToken.user.id,
          email: responseToken.user.email,
          nome: responseToken.user.nome,
          accessToken: responseToken.acessToken
        }));

        this.router.navigate(['tabs/']);
      }
    }, error => { console.log(error); }
    );
  }

}
