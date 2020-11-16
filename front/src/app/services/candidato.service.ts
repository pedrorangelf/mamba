
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class CandidatoService extends DataService {

  private accessToken: string;
  context = 'desafio';

  obterCandidatosPorVaga(id: any) {
    return this.get<any>(id + '/obter-inscricoes');
  }

  getLoggedUser() {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    return currentUser;
  }
}
