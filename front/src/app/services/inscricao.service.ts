import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { DataService } from './data.service';
import { DesafioModel } from '../shared/model/desafio-add.model';


@Injectable({
  providedIn: 'root'
})
export class InscricaoService extends DataService {

  context = 'inscricao';

  salvar(data: any) {
    return this.post<any>(data.desafioId, data);
  }

  obterDetalhesInscricao(id: string) {
    return this.get<any>('', id);
  }
}
