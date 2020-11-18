import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { DataService } from './data.service';
import { DesafioModel } from '../shared/model/desafio-add.model';


@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService extends DataService {

  context = 'avaliacao';

  salvar(data: any) {
    return this.post<any>('salvar-avaliacao-desafio/' + data.desafioId, data);
  }
}
