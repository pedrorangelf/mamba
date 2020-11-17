
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends DataService {

  private accessToken: string;
  context = 'login';

  login(email: string, senha: string) {
    return this.post<any>('', { email, senha });
  }

  getLoggedUser() {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    return currentUser;
  }
}
