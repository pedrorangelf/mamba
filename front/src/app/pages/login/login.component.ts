import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  formGroup: FormGroup;
  accessToken: string;

  constructor(private accountService: AccountService, private _formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.formGroup = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', Validators.required]
    });
  }
  ngOnDestroy() {
  }

  login() {
    this.accountService.login(this.formGroup.value.email, this.formGroup.value.senha).subscribe((response: any) => {

      const responseToken = response.data.json();

      if (responseToken) {
        this.accessToken = responseToken.acessToken;

        localStorage.setItem('currentUser', JSON.stringify({
          id: responseToken.user.id,
          email: responseToken.user.email,
          nome: responseToken.user.nome,
          accessToken: responseToken.acessToken
        }));

      }
    });

    if (this.accessToken) {
      this.router.navigate(['dashboard/']);
    }
  }

}
