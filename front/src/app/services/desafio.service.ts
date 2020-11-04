import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { DataService } from './data.service';
import { DesafioModel } from '../shared/model/desafio-add.model';


@Injectable({
    providedIn: 'root'
})
export class DesafioService extends DataService {

    context = 'desafio';

    salvar(data: any) {
        return this.post<any>('', data);
    }

    editar(data: DesafioModel) {
        return this.put<DesafioModel>(data.id, data);
    }

    excluir(id: string) {
        return this.delete<any>('', id);
    }

    buscarDesafioPorId(id: string) {
        return this.get<any>('', id);
    }

    listarDesafios() {
        return this.get<any>('');
    }
}
