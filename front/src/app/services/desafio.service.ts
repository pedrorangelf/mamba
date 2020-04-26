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
        return this.put<DesafioModel>('editar', data);
    }

    excluir(id: number) {
        return this.delete<any>('excluir', id);
    }

    buscarDesafioPorId(id: number) {
        return this.get<any>('', id);
    }

    listarDesafios() {
        return this.get<any>('');
    }
}
